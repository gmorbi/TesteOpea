using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Empresas.Domain.Entities.OAuth;
using Empresas.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using Empresas.Shared.Configurations;

namespace Empresas.Domain.Services;

public class AuthService : IAuthService
{
    private readonly IRepositoryOAuth _repositoryOAuth;
    private readonly TokenConfiguration _tokenConfiguration;
    const string tokenType = "Bearer";

    public AuthService(IRepositoryOAuth repositoryOAuth, TokenConfiguration tokenConfiguration)
    {
        _repositoryOAuth = repositoryOAuth;
        _tokenConfiguration = tokenConfiguration;
    }

    public async Task<OAuthLoginResponse> LoginAsync(OAuthLoginRequest request)
    {
        var user = await _repositoryOAuth.FindUserForLogin(request.ClientId, Sha256(request.ClientSecret));

        if (user == null)
            throw new Exception("User or Password incorrect");

        string token;

        switch (request.GrantType)
        {
            case "client_credentials":
                {
                    token = GenerateTokenByClientCredentials(request, user);
                    break;
                }
            default:
                {
                    throw new Exception("Grant Type is not defined");
                }
        }

        return new OAuthLoginResponse()
        {
            AccessToken = token,
            ExpiresIn = user.IdentityTokenLifetime,
            IssuedAt = DateTime.UtcNow.Millisecond,
            TokenType = tokenType,
        };
    }

    private string GenerateTokenByClientCredentials(OAuthLoginRequest request, OAuthClients user)
    {
        IList<Claim> permissions = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                new Claim(JwtRegisteredClaimNames.UniqueName, request.ClientId),

                new Claim(JwtRegisteredClaimNames.Sub, user.ClientName)
            };

        foreach (var item in user.OAuthClientScopes)
        {
            var scope = new { name = item.Scope.Name };

            permissions.Add(new Claim("ApiScopes", item.Scope.Name));
        }

        var tokenDescriptor = new JwtSecurityToken
            (
                issuer: _tokenConfiguration.Issuer,
                audience: _tokenConfiguration.Audience,
                claims: permissions,
                expires: DateTime.Now.AddSeconds(user.IdentityTokenLifetime),
                signingCredentials: _tokenConfiguration.SigningCredentials
            );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return token;
    }

    private string Sha256(string randomString)
    {
        var crypt = new SHA256Managed();

        string hash = string.Empty;

        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));

        foreach (byte theByte in crypto)
            hash += theByte.ToString("x2");

        return hash;
    }
}