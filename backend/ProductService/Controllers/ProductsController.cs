using Microsoft.AspNetCore.Mvc;
using MassTransit;
using ProductService.Models;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ProductsController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductCreated product)
    {
        await _publishEndpoint.Publish(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(Guid id)
    {
        return NotFound();
    }
}
