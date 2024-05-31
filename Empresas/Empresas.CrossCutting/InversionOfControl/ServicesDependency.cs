using Empresas.Application;
using Empresas.Application.Interfaces;
using Empresas.Application.Services;
using Empresas.Domain;
using Empresas.Domain.Interfaces;
using Empresas.Domain.Services;
using Empresas.Infra;
using Empresas.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Empresas.CrossCutting.InversionOfControl;

public static class ServicesDependency
{
    public static IServiceCollection AddServicesDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IRepositoryEmpresa, RepositoryEmpresa>();
        services.AddTransient<IServiceEmpresa, ServiceEmpresa>();
        services.AddTransient<IRepositoryOAuth, RepositoryOAuth>();
        services.AddTransient<IOAuthService, OAuthService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IEmpresaService, EmpresaService>();

        return services;
    }
}
