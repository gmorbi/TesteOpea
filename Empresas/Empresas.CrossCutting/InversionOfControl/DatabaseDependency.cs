using Empresas.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Empresas.CrossCutting.InversionOfControl;

public static class DatabaseDependency
{
    public static IServiceCollection AddDatabaseDependency(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnectionString");

        services.AddDbContext<EmpresaContext>(options 
            => options.UseSqlServer(connectionString, sqlServerOptionsAction => sqlServerOptionsAction.CommandTimeout(30)));   

        return services;
    }
}
