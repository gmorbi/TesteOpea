namespace Empresas.Domain.Entities.OAuth;

public partial class OAuthClientGrantTypes
{
    public Guid Id { get; set; }
    public string GrantType { get; set; }
    public Guid ClientId { get; set; }
    public virtual OAuthClients Client { get; set; }
}
