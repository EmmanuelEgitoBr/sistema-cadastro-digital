namespace Gestao.Cadastro.Digital.Infra.Messaging.Interfaces;

public interface IRabbitMqEventPublisher
{
    Task PublishAsync<T>(T message, string queue);
    ValueTask DisposeAsync();
}
