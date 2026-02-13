using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Query = Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorUsuarioIdQuery;

namespace Gestao.Cadastro.Digital.Application.Handlers.Queries.BuscarAuditoriaPorUsuarioIdQuery;

public class BuscarAuditoriaPorUsuarioIdQueryHandler :
    IRequestHandler<Query.BuscarAuditoriaPorUsuarioIdQuery, IEnumerable<AuditoriaQueryDto>>
{
    private readonly IAuditoriaService _auditoriaService;
    private readonly ILogger<BuscarAuditoriaPorUsuarioIdQueryHandler> _logger;

    public BuscarAuditoriaPorUsuarioIdQueryHandler(IAuditoriaService auditoriaService,
        ILogger<BuscarAuditoriaPorUsuarioIdQueryHandler> logger)
    {
        _auditoriaService = auditoriaService;
        _logger = logger;
    }

    public async Task<IEnumerable<AuditoriaQueryDto>> Handle(Query.BuscarAuditoriaPorUsuarioIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listaAuditorias = await _auditoriaService.RetornarAuditoriaPorUsuarioIdAsync(request.UsuarioId);
            if (listaAuditorias == null)
            {
                _logger.LogWarning($"Nenhuma auditoria encontrada para o id: {request.UsuarioId}");
                throw new DomainException("Nenhuma auditoria encontrada");
            }

            return listaAuditorias;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar buscar as auditorias");
            throw;
        }
    }
}
