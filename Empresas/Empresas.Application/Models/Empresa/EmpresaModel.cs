using Empresas.Application.ViewModel.Empresa;

namespace Empresas.Application.Models.Empresa;

public class EmpresaModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public EPorte Porte { get; set; }

    public Domain.Entities.Empresa ConvertToEmpresa()
    {
        return new Domain.Entities.Empresa()
        {
            Id = Id,
            Nome = Nome,
            Porte = (Domain.Enum.EPorte)Porte
        };
    }
}
