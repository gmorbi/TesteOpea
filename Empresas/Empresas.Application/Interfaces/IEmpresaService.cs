using Empresas.Application.Models.Empresa;
using Empresas.Application.ViewModel.Empresa;

namespace Empresas.Application;

public interface IEmpresaService
{
    Task<IEnumerable<EmpresaViewModel>> GetAllAsync();
    Task<EmpresaViewModel> GetByIdAsync(Guid id);
    Task<EmpresaViewModel> AddAsync(CreateEmpresa empresa);
    Task PutById(Guid id, CreateEmpresa empresa);
    Task DeleteById(Guid id);
}
