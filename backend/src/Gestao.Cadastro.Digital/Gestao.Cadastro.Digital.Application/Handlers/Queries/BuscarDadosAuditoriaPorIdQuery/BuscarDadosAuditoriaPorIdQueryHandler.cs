using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Query = Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarDadosAuditoriaPorIdQuery;

namespace Gestao.Cadastro.Digital.Application.Handlers.Queries.BuscarDadosAuditoriaPorIdQuery;

public class BuscarDadosAuditoriaPorIdQueryHandler :
    IRequestHandler<Query.BuscarDadosAuditoriaPorIdQuery, AuditoriaQueryDto>
{
    private readonly IAuditoriaService _auditoriaService;
    private readonly ILogger<BuscarDadosAuditoriaPorIdQueryHandler> _logger;

    public BuscarDadosAuditoriaPorIdQueryHandler(IAuditoriaService auditoriaService,
        ILogger<BuscarDadosAuditoriaPorIdQueryHandler> logger)
    {
        _auditoriaService = auditoriaService;
        _logger = logger;
    }

    public async Task<AuditoriaQueryDto> Handle(Query.BuscarDadosAuditoriaPorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var auditoriaQuery = await _auditoriaService.RetornarAuditoriaPorIdAsync(request.AuditoriaId);

            if (auditoriaQuery == null)
            {
                _logger.LogWarning($"Auditoria não encontrada para o Id: {request.AuditoriaId}");
                throw new DomainException("Auditoria não encontrada");
            }

            return auditoriaQuery;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar consultar auditoria");
            throw;
        }
    }
}