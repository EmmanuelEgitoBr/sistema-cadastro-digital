namespace Gestao.Cadastro.Digital.Application.DTOs;

public record CriarContatoDto
{
    public long IdPessoa { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}