using Empresas.Domain.Entities;
using Empresas.Domain.Interfaces;

namespace Empresas.Infra.Data.Repositories;

public class RepositoryEmpresa : RepositoryBase<Empresa>, IRepositoryEmpresa
{
    private readonly EmpresaContext _empresaContext;

    public RepositoryEmpresa(EmpresaContext empresaContext) 
        : base(empresaContext)
    {
        _empresaContext = empresaContext;
    }
}
