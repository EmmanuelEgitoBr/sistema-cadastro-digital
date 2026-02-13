namespace Gestao.Cadastro.Digital.Worker.Auditoria.Models
{
    public class AuditoriaContract
    {
        public long UsuarioId { get; set; }
        public string Login { get; set; } = string.Empty;
        public TipoAcao Acao { get; set; }
        public string Entidade { get; set; } = string.Empty;
        public object? DadosAntes { get; set; }
        public object? DadosDepois { get; set; }
    }
}
