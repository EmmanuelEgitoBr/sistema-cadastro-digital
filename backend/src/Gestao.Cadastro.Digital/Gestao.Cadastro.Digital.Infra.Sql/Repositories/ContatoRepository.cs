using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
{
    public ContatoRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Contato?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.Contatos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}
