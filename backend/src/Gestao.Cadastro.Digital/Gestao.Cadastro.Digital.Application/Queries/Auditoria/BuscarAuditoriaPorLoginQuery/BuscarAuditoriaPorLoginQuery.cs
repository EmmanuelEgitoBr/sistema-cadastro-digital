using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorLoginQuery;

public record BuscarAuditoriaPorLoginQuery(string Login) : IRequest<IEnumerable<AuditoriaQueryDto>>;
