using Empresas.Domain.Entities;
using Empresas.Domain.Entities.OAuth;
using Microsoft.EntityFrameworkCore;

namespace Empresas.Infra.Data;

public class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options) {}
    
    public DbSet<Empresa> Empresas { get; set; }

    public DbSet<OAuthClients> OAuthClients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpresaContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }
}
