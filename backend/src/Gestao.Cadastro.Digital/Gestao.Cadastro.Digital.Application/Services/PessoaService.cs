using Gestao.Cadastro.Digital.Application.Contracts.Auditoria;
using Gestao.Cadastro.Digital.Application.DTOs;
using Gestao.Cadastro.Digital.Application.Interfaces;
using Gestao.Cadastro.Digital.Domain.Constants;
using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Enums;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;
using Gestao.Cadastro.Digital.Infra.Messaging.Interfaces;

namespace Gestao.Cadastro.Digital.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRabbitMqEventPublisher _publiser;

    public PessoaService(IUnitOfWork unitOfWork, IRabbitMqEventPublisher publisher)
    {
        _unitOfWork = unitOfWork;
        _publiser = publisher;
    }

    public async Task<long> InserirPessoaFisicaAsync(CriarPessoaFisicaDto pessoaFisicaDto)
    {
        if (await CpfExisteAsync(pessoaFisicaDto.Cpf!))
            throw new DomainException("CPF já cadastrado.");

        PessoaFisica pessoaFisica = new PessoaFisica
        {
            TipoPessoa = TipoPessoa.Fisica,
            CategoriaPessoa = (CategoriaPessoa)pessoaFisicaDto.CategoriaPessoa,
            DataRegistro = DateTime.Now,
            DataInativacao = null,

            NomePessoa = pessoaFisicaDto.NomePessoa,
            NomePai = pessoaFisicaDto.NomePai,
            NomeMae = pessoaFisicaDto.NomeMae,
            NumeroRg = pessoaFisicaDto.NumeroRg,
            OrgaoExpedidorRg = pessoaFisicaDto.OrgaoExpedidorRg,
            UfExpedidorRg = pessoaFisicaDto.UfExpedidorRg,
            DataEmissaoRg = pessoaFisicaDto.DataEmissaoRg,
            Sexo = pessoaFisicaDto.Sexo,
            EstadoCivil = pessoaFisicaDto.EstadoCivil,
            Nacionalidade = pessoaFisicaDto.Nacionalidade,
            CidadeNascimento = pessoaFisicaDto.CidadeNascimento,
            UfNascimento = pessoaFisicaDto.UfNascimento,
            Cpf = pessoaFisicaDto.Cpf,
            DataNascimento = pessoaFisicaDto.DataNascimento
        };

        var blocoAuditoria = new AuditoriaContract
        {
            UsuarioId = 1,
            Login = "eegito",
            Acao = TipoAcao.Insercao,
            Entidade = TipoEntidades.TabelaPessoaFisica,
            DadosAntes = null,
            DadosDepois = pessoaFisica
        };

        await _publiser.PublishAsync(blocoAuditoria, "auditoria-queue");

        var idPessoa = await CriarPessoaFisicaAsync(pessoaFisica);

        return idPessoa;
    }

    public async Task<long> InserirPessoaJuridicaAsync(CriarPessoaJuridicaDto pessoaJuridicaDto)
    {
        var cnpjSemMascara = new string(pessoaJuridicaDto.Cnpj!.Where(char.IsDigit).ToArray());

        if (await CnpjExisteAsync(cnpjSemMascara))
            throw new DomainException("CNPJ já cadastrado.");

        PessoaJuridica pessoaJuridica = new PessoaJuridica
        {
            TipoPessoa = TipoPessoa.Juridica,
            CategoriaPessoa = (CategoriaPessoa)pessoaJuridicaDto.CategoriaPessoa,
            DataRegistro = DateTime.Now,
            DataInativacao = null,
            NomeResponsavel = pessoaJuridicaDto.NomeResponsavel,
            RazaoSocial = pessoaJuridicaDto.RazaoSocial,
            NomeFantasia = pessoaJuridicaDto.NomeFantasia,
            Cnpj = cnpjSemMascara,
            InscricaoEstadual = pessoaJuridicaDto.InscricaoEstadual,
            InscricaoMunicipal = pessoaJuridicaDto.InscricaoMunicipal,
            DataFundacao = pessoaJuridicaDto.DataFundacao,
            NaturezaJuridica = pessoaJuridicaDto.NaturezaJuridica,
            Cnae = pessoaJuridicaDto.Cnae
        };
        
        var idPessoa = await CriarPessoaJuridicaAsync(pessoaJuridica);

        return idPessoa;
    }

    public async Task<long> InserirContatoPessoaAsync(CriarContatoDto contatoDto)
    {
        Contato contato = new Contato
        {
            IdPessoa = contatoDto.IdPessoa,
            Email = contatoDto.Email,
            Telefone = contatoDto.Telefone
        };
        await _unitOfWork.Contatos.AddAsync(contato);
        await _unitOfWork.CommitAsync();
        return contato.IdContato;
    }

    public async Task<long> InserirEnderecoPessoaAsync(CriarEnderecoDto enderecoDto)
    {
        Endereco endereco = new Endereco
        {
            IdPessoa = enderecoDto.IdPessoa,
            Logradouro = enderecoDto.Logradouro,
            Numero = enderecoDto.Numero,
            Complemento = enderecoDto.Complemento,
            Bairro = enderecoDto.Bairro,
            Cidade = enderecoDto.Cidade,
            Estado = enderecoDto.Estado,
            Cep = enderecoDto.Cep
        };
        await _unitOfWork.Enderecos.AddAsync(endereco);
        await _unitOfWork.CommitAsync();
        return endereco.IdEndereco;
    }

    public async Task<long> InativarPessoaAsync(long idPessoa)
    {
        var pessoa = await _unitOfWork.Pessoas.GetByIdAsync(idPessoa);
        if (pessoa == null)
            throw new Exception("Pessoa não encontrada.");
        
        if (pessoa.DataInativacao != null)
            throw new Exception("Pessoa já está inativa.");

        pessoa.DataInativacao = DateTime.Now;
        
        _unitOfWork.Pessoas.Update(pessoa);
        await _unitOfWork.CommitAsync();
        
        return pessoa.IdPessoa;
    }

    #region Métodos privados

    private async Task<bool> CpfExisteAsync(string cpf)
    {
        return await _unitOfWork.PessoasFisicas.ExistsAsync(p => p.Cpf == cpf);
    }

    private async Task<bool> CnpjExisteAsync(string cnpj)
    {
        return await _unitOfWork.PessoasJuridicas.ExistsAsync(p => p.Cnpj == cnpj);
    }

    private async Task<long> CriarPessoaFisicaAsync(PessoaFisica pessoaFisica)
    {
        await _unitOfWork.PessoasFisicas.AddAsync(pessoaFisica);
        await _unitOfWork.CommitAsync();

        return pessoaFisica.IdPessoa;
    }

    private async Task<long> CriarPessoaJuridicaAsync(PessoaJuridica pessoaJuridica)
    {
        await _unitOfWork.PessoasJuridicas.AddAsync(pessoaJuridica);
        await _unitOfWork.CommitAsync();

        return pessoaJuridica.IdPessoa;
    }

    #endregion


}
