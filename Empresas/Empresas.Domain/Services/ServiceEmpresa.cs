using Empresas.Domain.Entities;
using Empresas.Domain.Interfaces;

namespace Empresas.Domain.Services;

public class ServiceEmpresa : ServiceBase<Empresa>, IServiceEmpresa
{
    private readonly IRepositoryEmpresa _repositoryEmpresa;

    public ServiceEmpresa(IRepositoryEmpresa repositoryEmpresa)
        : base(repositoryEmpresa)
    {
        _repositoryEmpresa = repositoryEmpresa;
    }
}
