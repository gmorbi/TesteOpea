using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Empresas.Application.Models.OAuth;
using Empresas.Application.ViewModel.OAuth;
using Empresas.Application.Interfaces;

namespace Empresas.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]

public class OAuthController : ControllerBase
{
    private readonly IOAuthService _authService;

    public OAuthController(IOAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("token"), AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] LoginModel request)
    {
        var response = await _authService.Login(request);
        return Ok(response);
    }
}
