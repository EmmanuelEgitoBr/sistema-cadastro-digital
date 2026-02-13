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
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        var properties = new BasicProperties
        {
            Persistent = true
        };

        var tcs = new TaskCompletionSource<bool>();

        channel.BasicAcksAsync += async (sender, ea) =>
        {
            tcs.TrySetResult(true);
            await Task.CompletedTask;
        };

        channel.BasicNacksAsync += async (sender, ea) =>
        {
            tcs.TrySetException(new Exception("Mensagem NÃO confirmada (NACK)"));
            await Task.CompletedTask;
        };

        await channel.BasicPublishAsync<BasicProperties>(
            exchange: "",
            routingKey: queue,
            mandatory: false,
            basicProperties: properties,
            body: body);

        var completedTask = await Task.WhenAny(
            tcs.Task,
            Task.Delay(TimeSpan.FromSeconds(5)));

        if (completedTask != tcs.Task)
        {
            throw new TimeoutException("Timeout aguardando confirmação do broker");
        }

        _logger.Information("Mensagem confirmada pelo RabbitMQ na fila {Queue}", queue);
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection.IsOpen)
            await _connection.CloseAsync();

        _connection.Dispose();
    }
}