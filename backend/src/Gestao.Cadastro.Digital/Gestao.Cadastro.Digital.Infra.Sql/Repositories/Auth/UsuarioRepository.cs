using Gestao.Cadastro.Digital.Domain.Entities.Auth;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auth;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Cadastro.Digital.Infra.Sql.Repositories.Auth;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorLoginAsync(string login)
    {
        return await _context.Usuarios
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u =>
                u.Email == login ||
                u.Login == login ||
                u.Cpf == login);
    }

    public async Task<RefreshToken?> ObterRefreshTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x =>
                x.Token == token &&
                x.Ativo &&
                x.ExpiraEm > DateTime.UtcNow);
    }

    public async Task SalvarRefreshTokenAsync(RefreshToken token)
    {
        var existente = await _context.RefreshTokens
            .FirstOrDefaultAsync(x =>
                x.UsuarioId == token.UsuarioId &&
                x.Ativo);

        if (existente != null)
            existente.Revogar();

        await _context.RefreshTokens.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario?> ObterPorIdAsync(long id)
        => await _context.Usuarios
            .Include(x => x.RefreshTokens)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UsuarioId == id);

    public async Task<Usuario?> ObterPorEmailAsync(string email)
        => await _context.Usuarios
            .Include(x => x.RefreshTokens)
            .FirstOrDefaultAsync(x => x.Email == email);

    public async Task<bool> ExisteEmailAsync(string email)
        => await _context.Usuarios.AnyAsync(x => x.Email == email);

    public async Task AdicionarAsync(Usuario usuario)
        => await _context.Usuarios.AddAsync(usuario);

    public Task AtualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        return Task.CompletedTask;
    }

    public async Task SalvarAlteracoesAsync()
        => await _context.SaveChangesAsync();
}
