using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresas.Infra;

public class OAuthClientSecretsMapping : IEntityTypeConfiguration<OAuthClientSecrets>
{
    public void Configure(EntityTypeBuilder<OAuthClientSecrets> builder)
    {
        builder.ToTable("CLIENT_SECRETS");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever().HasColumnType("UniqueIdentifier");

        builder.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

        builder.Property(e => e.Created).HasColumnName("CREATED").HasColumnType("DATE");

        builder.Property(e => e.Description).HasColumnName("DESCRIPTION").HasMaxLength(150).IsUnicode(false);

        builder.Property(e => e.Expiration).HasColumnName("EXPIRATION").HasColumnType("DATE");

        builder.Property(e => e.Type).IsRequired().HasColumnName("TYPE").HasMaxLength(50).IsUnicode(false);

        builder.Property(e => e.Value).IsRequired().HasColumnName("VALUE").HasMaxLength(150).IsUnicode(false);

        builder.HasOne(d => d.Client).WithMany(p => p.OAuthClientSecrets).HasForeignKey(d => d.ClientId).HasConstraintName("SYS_C00152414");
    }
}