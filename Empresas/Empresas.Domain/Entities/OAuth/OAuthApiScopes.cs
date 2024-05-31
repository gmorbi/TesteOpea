namespace Empresas.Domain.Entities.OAuth;

public partial class OAuthApiScopes
{
    public OAuthApiScopes()
    {
        OAuthClientScopes = new HashSet<OAuthClientScopes>();
    }

    public Guid Id { get; set; }
    public bool? Enable { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }

    public virtual ICollection<OAuthClientScopes> OAuthClientScopes { get; set; }
}
