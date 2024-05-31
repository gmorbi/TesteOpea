using System.ComponentModel.DataAnnotations;

namespace Empresas.Application.ViewModel.Empresa;

public class CreateEmpresa
{
    public string Nome { get; set; }

    [EnumDataType(typeof(EPorte), ErrorMessage = "Valor inválido para o porte da empresa.")]
    public EPorte Porte { get; set; }
}
