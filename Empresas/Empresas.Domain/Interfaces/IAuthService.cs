using Empresas.Domain.Entities.OAuth;

namespace Empresas.Domain.Interfaces;

public interface IAuthService
{
    Task<OAuthLoginResponse> LoginAsync(OAuthLoginRequest request);
}
