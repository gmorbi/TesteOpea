namespace Empresas.Domain.Entities.OAuth;

public class OAuthLoginRequest
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string GrantType { get; set; }
    public string Scope { get; set; }
}