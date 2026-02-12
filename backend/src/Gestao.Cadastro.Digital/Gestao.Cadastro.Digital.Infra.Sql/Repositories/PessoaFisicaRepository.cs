using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class PessoaFisicaRepository : RepositoryBase<PessoaFisica>, IPessoaFisicaRepository
{
    public PessoaFisicaRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<bool> ExistsAsync(Func<PessoaFisica, bool> predicate)
    {
        return await Task.FromResult(_context.PessoasFisicas.AsNoTracking().Any(predicate));
    }

    public async Task<PessoaFisica?> ObterPorCpfAsync(string cpf)
    {
        return await _context.PessoasFisicas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Cpf == cpf);
    }

    public async Task<PessoaFisica?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.PessoasFisicas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}
