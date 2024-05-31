using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra;

public class OAuthApiScopesMapping : IEntityTypeConfiguration<OAuthApiScopes>
{
    public void Configure(EntityTypeBuilder<OAuthApiScopes> builder)
    {
        builder.ToTable("API_SCOPES");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever().HasColumnType("UniqueIdentifier");

        builder.Property(e => e.Description).HasColumnName("DESCRIPTION").HasMaxLength(200).IsUnicode(false);

        builder.Property(e => e.DisplayName).HasColumnName("DISPLAY_NAME").HasMaxLength(100).IsUnicode(false);

        builder.Property(e => e.Enable).HasColumnName("ENABLE");

        builder.Property(e => e.Name).IsRequired().HasColumnName("NAME").HasMaxLength(100).IsUnicode(false);
    }
}
