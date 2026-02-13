namespace Gestao.Cadastro.Digital.Application.DTOs.Auditoria;

public class AuditoriaQueryDto
{
    public DateTime Data {  get; set; }
    public long UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public int Acao { get; set; }
    public string Entidade { get; set; } = string.Empty;
    public string? DadosAntes { get; set; }
    public string? DadosDepois { get; set; }
}
