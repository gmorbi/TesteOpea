using System.Runtime.CompilerServices;
using Empresas.Application.Models.Empresa;
using Empresas.Application.ViewModel.Empresa;
using Empresas.Domain.Entities;
using Empresas.Domain.Interfaces;

namespace Empresas.Application.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IServiceEmpresa _serviceEmpresa;

    public EmpresaService(IServiceEmpresa serviceEmpresa)
    {
        _serviceEmpresa = serviceEmpresa;
    }

    public async Task<EmpresaViewModel> AddAsync(CreateEmpresa empresa)
    {
        var newEmpresa = Empresa.Create(empresa.Nome, (Domain.Enum.EPorte)empresa.Porte);
        await _serviceEmpresa.AddAsync(newEmpresa);
        await _serviceEmpresa.Commit();
        return new EmpresaViewModel(newEmpresa);
    }

    public async Task DeleteById(Guid id)
    {
        var empresa = await _serviceEmpresa.GetByIdAsync(id);
        
        if(empresa == null)
            throw new KeyNotFoundException("Empresa não encontrada");

        _serviceEmpresa.Remove(empresa);
        await _serviceEmpresa.Commit();
    }

    public async Task<IEnumerable<EmpresaViewModel>> GetAllAsync()
    {
        var empresas = await _serviceEmpresa.GetAllAsync();
        return empresas.Select(x => new EmpresaViewModel(x)).ToList();
    }

    public async Task<EmpresaViewModel> GetByIdAsync(Guid id)
    {
        var empresa = await _serviceEmpresa.GetByIdAsync(id);

        if(empresa == null)
            throw new KeyNotFoundException("Empresa não encontrada");

        return new EmpresaViewModel(empresa);
    }

    public async Task PutById(Guid id, CreateEmpresa empresa)
    {
        var findEmpresa = await _serviceEmpresa.GetByIdAsync(id);

        if(findEmpresa == null)
            throw new KeyNotFoundException("Empresa não encontrada");
        
        findEmpresa.Nome = empresa.Nome;
        findEmpresa.Porte = (Domain.Enum.EPorte)empresa.Porte;

        _serviceEmpresa.Update(findEmpresa);
        await _serviceEmpresa.Commit();
    }
}
