using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Query = Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarAuditoriaPorLoginQuery;

namespace Gestao.Cadastro.Digital.Application.Handlers.Queries.BuscarAuditoriaPorLoginQuery;

public class BuscarAuditoriaPorLoginQueryHandler : IRequestHandler<Query.BuscarAuditoriaPorLoginQuery, IEnumerable<AuditoriaQueryDto>>
{
    private readonly IAuditoriaService _auditoriaService;
    private readonly ILogger<BuscarAuditoriaPorLoginQueryHandler> _logger;

    public BuscarAuditoriaPorLoginQueryHandler(IAuditoriaService auditoriaService,
        ILogger<BuscarAuditoriaPorLoginQueryHandler> logger)
    {
        _auditoriaService = auditoriaService;
        _logger = logger;
    }

    public async Task<IEnumerable<AuditoriaQueryDto>> Handle(Query.BuscarAuditoriaPorLoginQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var listaAuditorias = await _auditoriaService.RetornarAuditoriaPorLoginAsync(request.Login);
            if (listaAuditorias == null)
            {
                _logger.LogWarning($"Nenhuma auditoria encontrada para o login: {request.Login}");
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
