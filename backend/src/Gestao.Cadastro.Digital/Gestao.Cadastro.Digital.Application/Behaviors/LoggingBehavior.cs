using MediatR;
using Microsoft.Extensions.Logging;

namespace Gestao.Cadastro.Digital.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var name = typeof(TRequest).Name;

        _logger.LogInformation("Iniciando {RequestName} {@Request}",
            name, request);

        var response = await next();

        _logger.LogInformation("Finalizando {RequestName}", name);

        return response;
    }
}
