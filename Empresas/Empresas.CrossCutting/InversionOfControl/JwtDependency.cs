using Empresas.Shared.Configurations;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace Empresas.CrossCutting.InversionOfControl;

public static class JwtDependency
{
    public static IServiceCollection AddJwtDependency(this IServiceCollection services, IConfiguration configuration)
    {
        dynamic jwtSettingsData = configuration.GetSection("JwtSettings");

        string jwtSecretKey = jwtSettingsData["SecretJWTKey"];
        string audience = jwtSettingsData["Audience"];
        string issuer = jwtSettingsData["Issuer"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        TokenConfiguration tokenConfiguration = new TokenConfiguration()
        {
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = credentials
        };

        services.AddSingleton(tokenConfiguration);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer("Bearer", bearerOptions =>
        {
            var paramsValidation = bearerOptions.TokenValidationParameters;

            paramsValidation.IssuerSigningKey = tokenConfiguration.SigningCredentials.Key;

            paramsValidation.ValidAudience = tokenConfiguration.Audience;

            paramsValidation.ValidIssuer = tokenConfiguration.Issuer;

            paramsValidation.ValidateIssuerSigningKey = true;

            paramsValidation.ValidateLifetime = true;

            paramsValidation.ClockSkew = TimeSpan.Zero;
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("FrontEnd", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("ApiScopes", "front");
                policy.AddAuthenticationSchemes("Bearer");
                policy.Build();
            });
        });

        return services;
    }
}
