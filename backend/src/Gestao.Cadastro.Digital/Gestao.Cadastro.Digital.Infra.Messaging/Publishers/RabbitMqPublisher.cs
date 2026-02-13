using Gestao.Cadastro.Digital.Infra.Messaging.Configuration;
using Gestao.Cadastro.Digital.Infra.Messaging.Interfaces;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using Serilog;
using System.Text;
using System.Text.Json;

namespace Gestao.Cadastro.Digital.Infra.Messaging.Publishers;

public class RabbitMqPublisher : IRabbitMqEventPublisher
{
    private readonly RabbitMqSettings _settings;
    private readonly IConnection _connection;
    private readonly AsyncRetryPolicy _retryPolicy;
    private readonly ILogger _logger = Log.ForContext<RabbitMqPublisher>();

    public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
    {
        _settings = options.Value;

        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            Port = _settings.Port,
            UserName = _settings.UserName,
            Password = _settings.Password,
            VirtualHost = _settings.VirtualHost
        };

        _connection = Task.Run(async () =>
            await factory.CreateConnectionAsync()).GetAwaiter().GetResult();

        _retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(
                _settings.RetryCount,
                retryAttempt => TimeSpan.FromSeconds(_settings.RetryDelaySeconds),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Retry {retryCount} após {timeSpan.TotalSeconds}s: {exception.Message}");
                });
    }

    public async Task PublishAsync<T>(T message, string queue)
    {
        await _retryPolicy.ExecuteAsync(async () =>
        {
            await using var channel = await _connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queue,
                durable: true,
                exclusive: false,
                autoDelete: false);

            var body = Encoding.UTF8.GetBytes(
                JsonSerializer.Serialize(message));

            var properties = new BasicProperties
            {
                Persistent = true
            };

            var tcs = new TaskCompletionSource<bool>();

            channel.BasicAcksAsync += async (_, _) =>
            {
                tcs.TrySetResult(true);
                await Task.CompletedTask;
            };

            channel.BasicNacksAsync += async (_, _) =>
            {
                tcs.TrySetException(
                    new Exception("Mensagem NACK pelo broker"));
                await Task.CompletedTask;
            };

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: queue,
                mandatory: false,
                basicProperties: properties,
                body: body);

            var completed = await Task.WhenAny(
                tcs.Task,
                Task.Delay(5_000));

            if (completed != tcs.Task)
                throw new TimeoutException("Timeout aguardando confirmação");

            _logger.Information(
                "Mensagem confirmada na fila {Queue}", queue);
        });
    }


    public async ValueTask DisposeAsync()
    {
        if (_connection.IsOpen)
            await _connection.CloseAsync();

        _connection.Dispose();
    }
}