using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;
using Gestao.Cadastro.Digital.Infra.Sql.Context;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IPessoaRepository Pessoas
        => new PessoaRepository(_context);

    public IPessoaFisicaRepository PessoasFisicas
        => new PessoaFisicaRepository(_context);

    public IPessoaJuridicaRepository PessoasJuridicas
        => new PessoaJuridicaRepository(_context);

    public IContatoRepository Contatos
        => new ContatoRepository(_context);

    public IEnderecoRepository Enderecos
        => new EnderecoRepository(_context);

    public IFuncionarioRepository Funcionarios
        => new FuncionarioRepository(_context);

    public IClienteRepository Clientes
        => new ClienteRepository(_context);

    public IFornecedorRepository Fornecedores
        => new FornecedorRepository(_context);

    public async Task<int> CommitAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
        => _context.Dispose();
}
