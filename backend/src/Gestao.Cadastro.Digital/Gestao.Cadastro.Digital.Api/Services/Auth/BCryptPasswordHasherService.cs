using Gestao.Cadastro.Digital.Application.Interfaces.Auth;

namespace Gestao.Cadastro.Digital.Api.Services.Auth;

public class BCryptPasswordHasherService : IPasswordHasher
{
    public string Hash(string senha) 
        => BCrypt.Net.BCrypt.HashPassword(senha);

    public bool Verify(string senha, string hash) 
        => BCrypt.Net.BCrypt.Verify(senha, hash);
}
