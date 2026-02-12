using Gestao.Cadastro.Digital.Application.DTOs;
using Gestao.Cadastro.Digital.Domain.Enums;
using Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Gestao.Cadastro.Digital.Application.Interfaces;
using Gestao.Cadastro.Digital.Domain.Entities;

namespace Gestao.Cadastro.Digital.Application.Services;

public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;

    public PessoaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> InserirPessoaFisicaAsync(CriarPessoaFisicaDto pessoaFisicaDto)
    {
        Pessoa pessoa = new Pessoa
        {
            TipoPessoa = TipoPessoa.Fisica,
            CategoriaPessoa = (CategoriaPessoa)pessoaFisicaDto.CategoriaPessoa,
            DataRegistro = DateTime.Now,
            DataInativacao = null
        };

        var idPessoa = await CriarPessoaAsync(pessoa);

        PessoaFisica pessoaFisica = new PessoaFisica
        {
            IdPessoa = idPessoa,
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

        await CriarPessoaFisicaAsync(pessoaFisica);

        return idPessoa;
    }

    private async Task<long> CriarPessoaAsync(Pessoa pessoa)
    {
        await _unitOfWork.Pessoas.AddAsync(pessoa);
        await _unitOfWork.CommitAsync();

        return pessoa.IdPessoa;
    }

    private async Task CriarPessoaFisicaAsync(PessoaFisica pessoaFisica)
    {
        await _unitOfWork.PessoasFisicas.AddAsync(pessoaFisica);
        await _unitOfWork.CommitAsync();
    }
}
