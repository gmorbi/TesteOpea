using Empresas.Application.Interfaces;
using Empresas.Application.Models.OAuth;
using Empresas.Application.ViewModel.OAuth;
using Empresas.Domain.Interfaces;

namespace Empresas.Application.Services;

public class OAuthService : IOAuthService
{
    private readonly IAuthService _authService;

    public OAuthService(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginViewModel> Login(LoginModel request)
    {
        var response = await _authService.LoginAsync(request.ConvertToLoginRequest());

        return new LoginViewModel(response);
    }
}
