using Gestao.Cadastro.Digital.Worker.Auditoria.Configuration;
using Gestao.Cadastro.Digital.Worker.Auditoria.Interfaces;
using Gestao.Cadastro.Digital.Worker.Auditoria.Models;
using Gestao.Cadastro.Digital.Worker.Auditoria.Utils;
using Microsoft.Extensions.Options;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Model = Gestao.Cadastro.Digital.Worker.Auditoria.Models;

namespace Gestao.Cadastro.Digital.Worker.Auditoria
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMqSettings _settings;
        private IConnection? _connection;

        public Worker(ILogger<Worker> logger, 
                        IServiceProvider serviceProvider, 
                        IOptions<RabbitMqSettings> options)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var factory = new ConnectionFactory
                {
                    HostName = _settings.HostName,
                    Port = _settings.Port,
                    UserName = _settings.UserName,
                    Password = _settings.Password
                };

                _connection = await factory.CreateConnectionAsync(stoppingToken);
                var channel = await _connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(
                    queue: "auditoria-queue",
                    durable: true,
                    exclusive: false,
                    autoDelete: false);

                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (sender, ea) =>
                {
                    try
                    {
                        var json = Encoding.UTF8.GetString(ea.Body.ToArray());

                        var contract = JsonSerializer.Deserialize<AuditoriaContract>(json);

                        if (contract is null)
                        {
                            _logger.LogError("Mensagem inválida");
                            throw new Exception("Mensagem inválida");
                        }
                        
                        using var scope = _serviceProvider.CreateScope();
                        var api = scope.ServiceProvider.GetRequiredService<IAuditoriaApi>();

                        var auditoria = new Model.Auditoria
                        {
                            UsuarioId = contract.UsuarioId,
                            Login = contract.Login,
                            Acao = (int)contract.Acao,
                            Entidade = contract.Entidade,
                            ObjetoAuditoria = AuditoriaMapper.GerarHistorico(
                                contract.Entidade,
                                contract.Acao,
                                contract.DadosAntes,
                                contract.DadosDepois)
                        };

                        var auditoriaModel = new AuditoriaModel(auditoria);

                        await Policy
                            .Handle<Exception>()
                            .WaitAndRetryAsync(3, r => TimeSpan.FromSeconds(2))
                            .ExecuteAsync(() => api.SalvarAsync(auditoriaModel));

                        await channel.BasicAckAsync(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Erro ao processar: {ex.Message}");

                        await channel.BasicNackAsync(
                            ea.DeliveryTag,
                            false,
                            requeue: false);
                    }
                };

                await channel.BasicConsumeAsync(
                    queue: "auditoria-queue",
                    autoAck: false,
                    consumer: consumer);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_connection?.IsOpen == true)
                await _connection.CloseAsync(cancellationToken);

            await base.StopAsync(cancellationToken);
        }
    }
}
