using Colibri.Infrastructure;
using Colibri.Models.Commands.Statistic;
using Colibri.Models.Commands.TeamMember;
using Colibri.Models.Statistics;
using Colibri.Models.TeamMembers;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamMemberController : ControllerBase
{
    private readonly ITeamMemberService _teamMemberService;

    public TeamMemberController(ITeamMemberService teamMemberService)
    {
        _teamMemberService = teamMemberService;
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<TeamMember>>> Get(
        [FromQuery] GetTeamMemberCommand command, CancellationToken token = default)
    {
        var result = await _teamMemberService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<TeamMember>>> GetAll(
        [FromQuery] GetAllTeamMemberCommand command, CancellationToken token = default)
    {
        var result = await _teamMemberService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(
        [FromForm] CreateTeamMemberCommand command, CancellationToken token = default)
    {
        await _teamMemberService.Create(command, token)
            .ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<TeamMember>> Update(
        [FromForm] UpdateTeamMemberCommand command,
        CancellationToken token = default)
    {
        var result = await _teamMemberService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeleteTeamMemberCommand command,
        CancellationToken token = default)
    {
        await _teamMemberService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }
    
    [HttpPut("[action]")]
    public async Task<ActionResult<TeamMember>> UpdateVisibility(
        [FromForm] UpdateVisibilityTeamMemberCommand command, CancellationToken token = default)
    {
        var result = await _teamMemberService.UpdateVisibility(command, token)
            .ConfigureAwait(false);
        return result;
    }
}