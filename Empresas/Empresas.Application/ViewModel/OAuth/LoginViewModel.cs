using Empresas.Domain.Entities.OAuth;

namespace Empresas.Application.ViewModel.OAuth;

public class LoginViewModel
{
    public LoginViewModel(OAuthLoginResponse loginResponse)
    {
        token_type = loginResponse.TokenType;
        issued_at = loginResponse.IssuedAt;
        expires_in = loginResponse.ExpiresIn;
        access_token = loginResponse.AccessToken;
    }

    public string token_type { get; set; }
    public long issued_at { get; set; }
    public long expires_in { get; set; }
    public string access_token { get; set; }
}
