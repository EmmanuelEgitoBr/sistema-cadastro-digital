using FluentValidation;
using Gestao.Cadastro.Digital.Application;
using Gestao.Cadastro.Digital.Application.Behaviors;
using Gestao.Cadastro.Digital.Application.Interfaces;
using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Application.Interfaces.Auth;
using Gestao.Cadastro.Digital.Application.Services;
using Gestao.Cadastro.Digital.Application.Services.Auditoria;
using Gestao.Cadastro.Digital.Application.Services.Auth;
using Gestao.Cadastro.Digital.Domain.Constants;
using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auth;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;
using Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;
using Gestao.Cadastro.Digital.Infra.Messaging.Configuration;
using Gestao.Cadastro.Digital.Infra.Messaging.HealthChecks;
using Gestao.Cadastro.Digital.Infra.Messaging.Interfaces;
using Gestao.Cadastro.Digital.Infra.Messaging.Publishers;
using Gestao.Cadastro.Digital.Infra.MongoDb.Configuration;
using Gestao.Cadastro.Digital.Infra.MongoDb.Context;
using Gestao.Cadastro.Digital.Infra.MongoDb.Repositories;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Auth;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace Gestao.Cadastro.Digital.CrossCutting.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
        services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAuditoriaService, AuditoriaService>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }

    public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);

        return services;
    }

    public static IServiceCollection  AddAuthenticationConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
                };
            });
            
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Role.Admin, policy => policy.RequireRole(Role.Admin));
            options.AddPolicy(Role.User, policy => policy.RequireRole(Role.User));
        });

        return services;
    }

    public static IServiceCollection AddMongoConfiguration(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<MongoDbContext>();
        services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();
        return services;
    }

    public static IServiceCollection AddMessagingConfiguration(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMq"));
        services.AddSingleton<IRabbitMqEventPublisher, RabbitMqPublisher>();

        return services;
    }

    public static IServiceCollection AddHealthChecksConfiguration(this IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck<RabbitMqHealthCheck>("rabbitmq");
        return services;
    }
}
