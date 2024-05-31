using Microsoft.IdentityModel.Tokens;

namespace Empresas.Shared.Configurations;

public class TokenConfiguration
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public SigningCredentials SigningCredentials{ get; set; }
}
