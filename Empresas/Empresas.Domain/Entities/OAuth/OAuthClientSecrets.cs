namespace Empresas.Domain.Entities.OAuth;

public partial class OAuthClientSecrets
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
    public DateTime? Expiration { get; set; }
    public string Type { get; set; }
    public DateTime? Created { get; set; }
    public Guid ClientId { get; set; }

    public virtual OAuthClients Client { get; set; }
}
