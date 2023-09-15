using Colibri.Infrastructure;
using Colibri.Models.Commands.Partners;
using Colibri.Models.Partners;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class PartnersController : ControllerBase
{
    private readonly IPartnersService _partnersService;

    public PartnersController(IPartnersService partnersService)
    {
        _partnersService = partnersService;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Partner>> Create(
        [FromForm] CreatePartnerCommand command,
        CancellationToken token = default)
    {
        var result = await _partnersService.Create(command, token)
            .ConfigureAwait(false);
        return result;
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Partner>>> Get(
        [FromQuery] GetPartnerCommand command, CancellationToken token = default)
    {
        var result = await _partnersService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Partner>>> GetAll(
        [FromQuery] GetAllPartnerCommand command, CancellationToken token = default)
    {
        var result = await _partnersService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Partner>>> GetGrouped(
        [FromQuery] GetGroupedPartnerCommand command, CancellationToken token = default)
    {
        var result = await _partnersService.GetGrouped(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Partner>> Update(
        [FromForm] UpdatePartnerCommand command,
        CancellationToken token = default)
    {
        var result = await _partnersService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeletePartnerCommand command,
        CancellationToken token = default)
    {
        await _partnersService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult<Partner>> UpdateVisibility(
        [FromForm] UpdateVisibilityPartnerCommand command,
        CancellationToken token = default)
    {
        var result = await _partnersService.UpdateVisibility(command, token)
            .ConfigureAwait(false);
        return (result);
    }
    
    
}