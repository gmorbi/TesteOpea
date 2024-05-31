using Empresas.Domain.Enum;

namespace Empresas.Domain.Entities;

public class Empresa : Base
{
    public string Nome { get; set; }
    public EPorte Porte { get; set; }
    
    public Empresa() {}

    private Empresa(string nome, EPorte porte)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Porte = porte;
    }

    public static Empresa Create(string nome, EPorte porte)
    => new Empresa(nome, porte);
}
