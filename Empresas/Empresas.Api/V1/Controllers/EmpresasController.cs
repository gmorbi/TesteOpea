using Empresas.Application;
using Empresas.Application.Models.Empresa;
using Empresas.Application.ViewModel.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Empresas.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer", Policy = "FrontEnd")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresasController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<EmpresaViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmpresas()
    {
        var empresas = await _empresaService.GetAllAsync();
        return Ok(empresas);
    }

    [HttpGet("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmpresa(Guid id)
    {
        var empresa = await _empresaService.GetByIdAsync(id);
        return Ok(empresa);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(EmpresaViewModel), StatusCodes.Status201Created)]
    public async Task<IActionResult> PostEmpresa([FromBody] CreateEmpresa empresa)
    {
        var createdEmpresa = await _empresaService.AddAsync(empresa);
        return CreatedAtAction(nameof(GetEmpresa), new { id = createdEmpresa.Id }, createdEmpresa);
    }

    [HttpPut("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutEmpresa(Guid id, [FromBody] CreateEmpresa empresa)
    {
        await _empresaService.PutById(id, empresa);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteEmpresa(Guid id)
    {
        await _empresaService.DeleteById(id);
        return NoContent();
    }
}
