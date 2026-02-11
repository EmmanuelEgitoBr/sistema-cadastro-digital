using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Fornecedor?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.Fornecedores
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}