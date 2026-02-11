namespace Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPessoaRepository Pessoas { get; }
    IFuncionarioRepository Funcionarios { get; }
    IClienteRepository Clientes { get; }
    IFornecedorRepository Fornecedores { get; }

    Task<int> CommitAsync();
}
