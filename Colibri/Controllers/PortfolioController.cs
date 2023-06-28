using Colibri.Infrastructure;
using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Portfolios;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class PortfolioController : ControllerBase
{
    private readonly IPortfolioService _portfolioService;

    public PortfolioController(IPortfolioService portfolioService)
    {
        _portfolioService = portfolioService;
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Portfolio>>> Get(
        [FromQuery] GetPortfolioCommand command, CancellationToken token = default)
    {
        var result = await _portfolioService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Portfolio>>> GetAll(
        [FromQuery] GetAllPortfolioCommand command, CancellationToken token = default)
    {
        var result = await _portfolioService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(
        [FromForm] CreatePortfolioCommand command, CancellationToken token = default)
    {
        await _portfolioService.Create(command, token)
            .ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Portfolio>> Update(
        [FromForm] UpdatePortfolioCommand command,
        CancellationToken token = default)
    {
        var result = await _portfolioService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeletePortfolioCommand command,
        CancellationToken token = default)
    {
        await _portfolioService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }
    
    [HttpPut("[action]")]
    public async Task<ActionResult<Portfolio>> UpdateVisibility(
        [FromForm] UpdateVisibilityPortfolioCommand command, CancellationToken token = default)
    {
        var result = await _portfolioService.UpdateVisibility(command, token)
            .ConfigureAwait(false);
        return result;
    }
}