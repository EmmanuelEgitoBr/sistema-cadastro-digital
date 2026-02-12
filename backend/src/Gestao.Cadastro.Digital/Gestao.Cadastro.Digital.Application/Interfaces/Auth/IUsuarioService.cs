using Gestao.Cadastro.Digital.Domain.Entities.Auth;

namespace Gestao.Cadastro.Digital.Application.Interfaces.Auth;

public interface IUsuarioService
{
    Task<Usuario?> ObterPorLoginAsync(string login);
    Task<RefreshToken?> ObterRefreshTokenAsync(string token);
    Task SalvarRefreshTokenAsync(RefreshToken token);
}
