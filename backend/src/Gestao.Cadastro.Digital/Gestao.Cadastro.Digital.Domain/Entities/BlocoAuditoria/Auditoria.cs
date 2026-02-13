using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;

public class Auditoria
{
    [BsonId]
    public ObjectId Id { get; set; }
    public DateTime Data { get; set; }
    public long UsuarioId { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public string Acao { get; set; } = string.Empty;
    public string Entidade { get; set; } = string.Empty;  //Relacionada com a classe/tabela
    public object DadosAntes { get; set; } = new object();
    public object DadosDepois { get; set; } = new object();
}