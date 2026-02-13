namespace Gestao.Cadastro.Digital.Worker.Auditoria.Models;

public class Auditoria
{
    public long UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public int Acao { get; set; }
    public string Entidade { get; set; } = string.Empty;
    public string? ObjetoAuditoria { get; set; } = string.Empty;
}
