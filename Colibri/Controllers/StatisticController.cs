using Colibri.Infrastructure;
using Colibri.Models.Commands.Statistic;
using Colibri.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class StatisticController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Statistic>>> Get(
        [FromQuery] GetStatisticCommand command, CancellationToken token = default)
    {
        var result = await _statisticService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Statistic>>> GetAll(
        [FromQuery] GetAllStatisticCommand command, CancellationToken token = default)
    {
        var result = await _statisticService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(
        [FromForm] CreateStatisticCommand command, CancellationToken token = default)
    {
        await _statisticService.Create(command, token)
            .ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Statistic>> Update(
        [FromForm] UpdateStatisticCommand command,
        CancellationToken token = default)
    {
        var result = await _statisticService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeleteStatisticCommand command,
        CancellationToken token = default)
    {
        await _statisticService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }
    
    [HttpPut("[action]")]
    public async Task<ActionResult<Statistic>> UpdateVisibility(
        [FromForm] UpdateVisibilityStatisticCommand command, CancellationToken token = default)
    {
        var result = await _statisticService.UpdateVisibility(command, token)
            .ConfigureAwait(false);
        return result;
    }
}