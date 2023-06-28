using Colibri.Infrastructure;
using Colibri.Models.Commands.Review;
using Colibri.Models.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;
[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Review>>> Get(
        [FromQuery] GetReviewCommand command, CancellationToken token = default)
    {
        var result = await _reviewService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Review>>> GetAll(
        [FromQuery] GetAllReviewCommand command, CancellationToken token = default)
    {
        var result = await _reviewService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(
        [FromForm] CreateReviewCommand command, CancellationToken token = default)
    {
        await _reviewService.Create(command, token)
            .ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Review>> Update(
        [FromForm] UpdateReviewCommand command,
        CancellationToken token = default)
    {
        var result = await _reviewService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeleteReviewCommand command,
        CancellationToken token = default)
    {
        await _reviewService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }
    
    [HttpPut("[action]")]
    public async Task<ActionResult<Review>> UpdateVisibility(
        [FromForm] UpdateVisibilityReviewCommand command, CancellationToken token = default)
    {
        var result = await _reviewService.UpdateVisibility(command, token)
            .ConfigureAwait(false);
        return result;
    }
}