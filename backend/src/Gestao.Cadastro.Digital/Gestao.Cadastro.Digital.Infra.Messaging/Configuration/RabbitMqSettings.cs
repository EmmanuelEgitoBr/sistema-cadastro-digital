namespace Gestao.Cadastro.Digital.Infra.Messaging.Configuration;

public class RabbitMqSettings
{
    public string HostName { get; set; } = default!;
    public int Port { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string VirtualHost { get; set; } = "/";
    public int RetryCount { get; set; }
    public int RetryDelaySeconds { get; set; }
}
