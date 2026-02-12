namespace Gestao.Cadastro.Digital.Application.Interfaces.Auth;

public interface IPasswordHasher
{
    string Hash(string senha);
    bool Verify(string senha, string hash);
}
