namespace Gestao.Cadastro.Digital.Application.DTOs.Auditoria;

public class AuditoriaDto
{
    public long UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public int Acao { get; set; }
    public string Entidade { get; set; } = string.Empty;  //Relacionada com a classe/tabela
    public string? DadosAntes { get; set; }
    public string? DadosDepois { get; set; }
}
