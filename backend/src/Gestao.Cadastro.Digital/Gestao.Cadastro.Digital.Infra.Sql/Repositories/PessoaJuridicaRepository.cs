using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class PessoaJuridicaRepository : RepositoryBase<PessoaJuridica>, IPessoaJuridicaRepository
{
    public PessoaJuridicaRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<PessoaJuridica?> ObterPorCnpjAsync(string cnpj)
    {
        return await _context.PessoasJuridicas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Cnpj == cnpj);
    }

    public async Task<PessoaJuridica?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.PessoasJuridicas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}
