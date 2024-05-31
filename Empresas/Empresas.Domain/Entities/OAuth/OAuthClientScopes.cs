namespace Empresas.Domain.Entities.OAuth;

public partial class OAuthClientScopes
{
    public Guid Id { get; set; }
    public Guid ScopeId { get; set; }
    public Guid ClientId { get; set; }

    public virtual OAuthClients Client { get; set; }
    public virtual OAuthApiScopes Scope { get; set; }
}
