using Empresas.Domain.Entities.OAuth;

namespace Empresas.Application.Models.OAuth;

public class LoginModel
{
    public string grant_type { get; set; }
    public string client_id { get; set; }
    public string client_secret { get; set; }

    public OAuthLoginRequest ConvertToLoginRequest()
    {
        return new OAuthLoginRequest
        {
            ClientId = client_id,
            GrantType = grant_type,
            ClientSecret = client_secret
        };
    }
}
