using Empresas.Application.Models.OAuth;
using Empresas.Application.ViewModel.OAuth;

namespace Empresas.Application.Interfaces;

public interface IOAuthService
{
    Task<LoginViewModel> Login(LoginModel request);
}
