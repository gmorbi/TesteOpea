using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra;

public class OAuthClientGrantTypesMapping : IEntityTypeConfiguration<OAuthClientGrantTypes>
{
    public void Configure(EntityTypeBuilder<OAuthClientGrantTypes> builder)
    {
        builder.ToTable("CLIENT_GRANT_TYPES");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever().HasColumnType("UniqueIdentifier");

        builder.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

        builder.Property(e => e.GrantType).IsRequired().HasColumnName("GRANT_TYPE").HasMaxLength(100).IsUnicode(false);

        builder.HasOne(d => d.Client).WithMany(p => p.OAuthClientGrantTypes).HasForeignKey(d => d.ClientId);
    }
}