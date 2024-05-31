namespace Empresas.Application.ViewModel.Empresa;

public class EmpresaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public EPorte Porte { get; set; }
    
    public EmpresaViewModel(Domain.Entities.Empresa empresa)
    {
        Id = empresa.Id;
        Nome = empresa.Nome;
        Porte = (EPorte)empresa.Porte;
    }
}
