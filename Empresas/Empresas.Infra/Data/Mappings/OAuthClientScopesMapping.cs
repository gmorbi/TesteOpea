using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra;

public class OAuthClientScopesMapping : IEntityTypeConfiguration<OAuthClientScopes>
{
    public void Configure(EntityTypeBuilder<OAuthClientScopes> builder)
    {
        builder.ToTable("CLIENT_SCOPES");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever().HasColumnType("UniqueIdentifier");

        builder.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

        builder.Property(e => e.ScopeId).HasColumnName("SCOPE_ID");

        builder.HasOne(d => d.Client).WithMany(p => p.OAuthClientScopes).HasForeignKey(d => d.ClientId);

        builder.HasOne(d => d.Scope).WithMany(p => p.OAuthClientScopes).HasForeignKey(d => d.ScopeId);
    }
}
