using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra;

public class OAuthClientMapping : IEntityTypeConfiguration<OAuthClients>
{
    public void Configure(EntityTypeBuilder<OAuthClients> builder)
    {
        builder.ToTable("CLIENTS");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever().HasColumnType("UniqueIdentifier");

        builder.Property(e => e.ClientId).IsRequired().HasColumnName("CLIENT_ID").HasMaxLength(200).IsUnicode(false);

        builder.Property(e => e.ClientName).HasColumnName("CLIENT_NAME").HasMaxLength(150).IsUnicode(false);

        builder.Property(e => e.Created).HasColumnName("CREATED").HasColumnType("DATE");

        builder.Property(e => e.Description).HasColumnName("DESCRIPTION").HasMaxLength(250).IsUnicode(false);

        builder.Property(e => e.Enabled).HasColumnName("ENABLED");

        builder.Property(e => e.IdentityTokenLifetime).HasColumnName("IDENTITY_TOKEN_LIFETIME");

        builder.Property(e => e.ProtocolType).IsRequired().HasColumnName("PROTOCOL_TYPE").HasMaxLength(50).IsUnicode(false);

        builder.Property(e => e.RequireClientSecret).HasColumnName("REQUIRE_CLIENT_SECRET");
    }
}
