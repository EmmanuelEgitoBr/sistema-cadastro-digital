using Gestao.Cadastro.Digital.Infra.Messaging.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Gestao.Cadastro.Digital.Infra.Messaging.HealthChecks;

public class RabbitMqHealthCheck : IHealthCheck
{
    private readonly RabbitMqSettings _settings;

    public RabbitMqHealthCheck(IOptions<RabbitMqSettings> options)
    {
        _settings = options.Value;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                Port = _settings.Port,
                UserName = _settings.UserName,
                Password = _settings.Password,
                VirtualHost = _settings.VirtualHost
            };

            await using var connection = await factory.CreateConnectionAsync();

            return HealthCheckResult.Healthy("RabbitMQ está disponível");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                "RabbitMQ indisponível",
                ex);
        }
    }
}