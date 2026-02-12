namespace Gestao.Cadastro.Digital.Application.DTOs.Response;

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

    public AuthResponseDto(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}
