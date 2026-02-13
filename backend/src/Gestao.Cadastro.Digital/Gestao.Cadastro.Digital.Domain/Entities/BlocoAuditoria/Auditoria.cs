using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;

public class Auditoria
{
    [BsonId]
    public ObjectId Id { get; set; }
    public DateTime Data { get; set; }
    public long UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public int Acao { get; set; }
    public string Entidade { get; set; } = string.Empty;  //Relacionada com a classe/tabela
    public string? ObjetoAuditoria {  get; set; } = string.Empty;
}