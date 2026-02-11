using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
{
    public PessoaRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Pessoa?> ObterCompletoAsync(long idPessoa)
    {
        return await _context.Pessoas
            .Include(x => x.ContatoPessoa)
            .Include(x => x.EnderecoPessoa)
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }

    public async Task<bool> ExisteDocumentoAsync(string documento)
    {
        return await _context.Pessoas
            .OfType<PessoaFisica>()
            .AnyAsync(x => x.Cpf == documento)
            ||
            await _context.Pessoas
            .OfType<PessoaJuridica>()
            .AnyAsync(x => x.Cnpj == documento);
    }
}
