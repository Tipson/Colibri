using Colibri.Infrastructure;
using Colibri.Models.Commands.Product;
using Colibri.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Product>>> Get(
        [FromQuery] GetProductCommand command, CancellationToken token = default)
    {
        var result = await _productService.Get(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }
    
    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll(
        [FromQuery] GetAllProductCommand command, CancellationToken token = default)
    {
        var result = await _productService.GetAll(command, token)
            .ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(
        [FromQuery] CreateProductCommand command, CancellationToken token = default)
    {
        await _productService.Create(command, token)
            .ConfigureAwait(false);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<Product>> Update(
        [FromQuery] UpdateProductCommand command,
        CancellationToken token = default)
    {
        var result = await _productService.Update(command, token)
            .ConfigureAwait(false);
        return result;
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult> Delete(
        [FromQuery] DeleteProductCommand command,
        CancellationToken token = default)
    {
        await _productService.Delete(command, token)
            .ConfigureAwait(false);
        return NoContent();
    }
}