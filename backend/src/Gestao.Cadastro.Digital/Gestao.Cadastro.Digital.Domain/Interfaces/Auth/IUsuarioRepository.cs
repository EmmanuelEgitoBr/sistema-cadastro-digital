using Gestao.Cadastro.Digital.Domain.Entities.Auth;

namespace Gestao.Cadastro.Digital.Domain.Interfaces.Auth;

public interface IUsuarioRepository
{
    Task<Usuario?> ObterPorLoginAsync(string login);
    Task<RefreshToken?> ObterRefreshTokenAsync(string token);
    Task SalvarRefreshTokenAsync(RefreshToken token);
    Task<Usuario?> ObterPorIdAsync(long id);
    Task<Usuario?> ObterPorEmailAsync(string email);

    Task AdicionarAsync(Usuario usuario);
    Task AtualizarAsync(Usuario usuario);

    Task<bool> ExisteEmailAsync(string email);

    Task SalvarAlteracoesAsync();
}