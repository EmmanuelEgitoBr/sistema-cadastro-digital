namespace Gestao.Cadastro.Digital.Domain.Entities.Auth;

public class Usuario
{
    public long UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public string? Nome { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string SenhaHash { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
    public DateTime DataRegistro { get; set; } = DateTime.Now;
    public DateTime? DataInativacao { get; set; }
    public string? Role { get; set; }
    public List<RefreshToken> RefreshTokens { get; private set; } = new();

    public bool PodeLogar() => Ativo;
}
