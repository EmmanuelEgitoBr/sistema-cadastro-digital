using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarDadosAuditoriaPorIdQuery;

public record BuscarDadosAuditoriaPorIdQuery(string AuditoriaId) : IRequest<AuditoriaQueryDto>;
