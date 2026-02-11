using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories;

public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(ApplicationDbContext context)
        : base(context) { }

    public async Task<Endereco?> ObterPorPessoaAsync(long idPessoa)
    {
        return await _context.Enderecos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdPessoa == idPessoa);
    }
}