using Empresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra.Data.Mappings;

public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("EMPRESAS");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired().HasColumnType("UniqueIdentifier");
        builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("Varchar(200)");
        builder.Property(x => x.Porte).HasColumnName("PORTE").HasColumnType("Varchar(50)");
    }
}