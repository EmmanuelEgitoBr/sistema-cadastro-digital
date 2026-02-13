using Gestao.Cadastro.Digital.Application.Interfaces.Auth;
using Gestao.Cadastro.Digital.Domain.Entities.Auth;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auth;

namespace Gestao.Cadastro.Digital.Application.Services.Auth;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task AdicionarAsync(Usuario usuario)
    {
        return _usuarioRepository.AdicionarAsync(usuario);
    }

    public Task AtualizarAsync(Usuario usuario)
    {
        return _usuarioRepository.AtualizarAsync(usuario);
    }

    public Task<bool> ExisteEmailAsync(string email)
    {
        return _usuarioRepository.ExisteEmailAsync(email);
    }

    public Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return _usuarioRepository.ObterPorEmailAsync(email);
    }

    public Task<Usuario?> ObterPorIdAsync(long id)
    {
        return _usuarioRepository.ObterPorIdAsync(id);
    }

    public async Task<Usuario?> ObterPorLoginAsync(string login)
    {
        return await _usuarioRepository.ObterPorLoginAsync(login);
    }

    public async Task<RefreshToken?> ObterRefreshTokenAsync(string token)
    {
        return await _usuarioRepository.ObterRefreshTokenAsync(token);
    }

    public Task SalvarAlteracoesAsync()
    {
        return _usuarioRepository.SalvarAlteracoesAsync();
    }

    public async Task SalvarRefreshTokenAsync(RefreshToken token)
    {
        await _usuarioRepository.SalvarRefreshTokenAsync(token);
    }
}
