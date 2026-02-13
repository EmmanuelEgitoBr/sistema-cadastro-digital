using Gestao.Cadastro.Digital.Worker.Auditoria;
using Gestao.Cadastro.Digital.Worker.Auditoria.Configuration;
using Gestao.Cadastro.Digital.Worker.Auditoria.Interfaces;
using Refit;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(config =>
{
    config.WriteTo.Console();
});

builder.Services
    .AddRefitClient<IAuditoriaApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://localhost:7249");
    });

builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMq"));

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
