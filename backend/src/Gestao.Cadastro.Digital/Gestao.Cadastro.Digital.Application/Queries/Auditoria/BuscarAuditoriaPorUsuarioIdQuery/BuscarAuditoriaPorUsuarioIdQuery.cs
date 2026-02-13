using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorUsuarioIdQuery;

public class BuscarAuditoriaPorUsuarioIdQuery(long UsuarioId) :
    IRequest<IEnumerable<AuditoriaQueryDto>>
{
    public long UsuarioId { get; } = UsuarioId;
}
