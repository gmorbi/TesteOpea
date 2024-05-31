namespace Empresas.Domain.Entities.OAuth;

public partial class OAuthClients
{
    public OAuthClients()
    {
        OAuthClientGrantTypes = new HashSet<OAuthClientGrantTypes>();
        OAuthClientScopes = new HashSet<OAuthClientScopes>();
        OAuthClientSecrets = new HashSet<OAuthClientSecrets>();
    }

    public Guid Id { get; set; }
    public bool? Enabled { get; set; }
    public string ClientId { get; set; }
    public string ProtocolType { get; set; }
    public bool? RequireClientSecret { get; set; }
    public string ClientName { get; set; }
    public string Description { get; set; }
    public long IdentityTokenLifetime { get; set; }
    public DateTime? Created { get; set; }

    public virtual ICollection<OAuthClientGrantTypes> OAuthClientGrantTypes { get; set; }
    public virtual ICollection<OAuthClientScopes> OAuthClientScopes { get; set; }
    public virtual ICollection<OAuthClientSecrets> OAuthClientSecrets { get; set; }
}
