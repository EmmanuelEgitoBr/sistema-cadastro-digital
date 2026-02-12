using Gestao.Cadastro.Digital.Domain.Entities.Auth;

namespace Gestao.Cadastro.Digital.Application.Interfaces.Auth;

public interface IJwtTokenService
{
    string GerarToken(Usuario usuario);
    string GerarRefreshToken();
}
