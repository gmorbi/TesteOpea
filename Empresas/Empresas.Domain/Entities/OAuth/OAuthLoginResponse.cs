namespace Empresas.Domain.Entities.OAuth;

public class OAuthLoginResponse
{
    public string TokenType { get; set; }
    public long IssuedAt { get; set; }
    public long ExpiresIn { get; set; }
    public string AccessToken { get; set; }
}
