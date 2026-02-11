namespace Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPessoaRepository Pessoas { get; }
    IPessoaFisicaRepository PessoasFisicas { get; }
    IPessoaJuridicaRepository PessoasJuridicas { get; }
    IContatoRepository Contatos { get; }
    IEnderecoRepository Enderecos { get; }
    IFuncionarioRepository Funcionarios { get; }
    IClienteRepository Clientes { get; }
    IFornecedorRepository Fornecedores { get; }

    Task<int> CommitAsync();
}
