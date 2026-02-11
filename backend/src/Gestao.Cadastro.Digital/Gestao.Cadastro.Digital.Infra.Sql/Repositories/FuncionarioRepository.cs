using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Funcionario?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.Funcionarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}
