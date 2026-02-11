using Gestao.Cadastro.Digital.Domain.Interfaces;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;
using Gestao.Cadastro.Digital.Domain.Interfaces.UnitOfWork;
using Gestao.Cadastro.Digital.Infra.Sql.Context;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.Base;
using Gestao.Cadastro.Digital.Infra.Sql.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        
        return services;
    }
}
