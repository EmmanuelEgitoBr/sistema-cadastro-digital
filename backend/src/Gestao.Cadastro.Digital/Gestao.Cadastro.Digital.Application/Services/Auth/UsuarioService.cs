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

    public async Task<Usuario?> ObterPorLoginAsync(string login)
    {
        return await _usuarioRepository.ObterPorLoginAsync(login);
    }

    public async Task<RefreshToken?> ObterRefreshTokenAsync(string token)
    {
        return await _usuarioRepository.ObterRefreshTokenAsync(token);
    }

    public async Task SalvarRefreshTokenAsync(RefreshToken token)
    {
        await _usuarioRepository.SalvarRefreshTokenAsync(token);
    }
}
