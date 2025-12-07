using Inventory.Application.Features.Products.Commands;
using Inventory.Application.Features.Products.Queries;
using Inventory.Application.Responses.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Create([FromBody] CreateProductResponse dto)
    {
        var command = new CreateProductCommand
        {
            Name = dto.Name,
            Description = dto.Description,
            SectionId = dto.SectionId,
            SKU = dto.SKU,
            Price = dto.Price,
            AvailableQuantity = dto.AvailableQuantity,
            ProductType = dto.ProductType,
            IsActive = dto.IsActive
        };

        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponse>> Update(Guid id, [FromBody] UpdateProductResponse dto)
    {
        var command = new UpdateProductCommand
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            SectionId = dto.SectionId,
            SKU = dto.SKU,
            Price = dto.Price,
            AvailableQuantity = dto.AvailableQuantity,
            ProductType = dto.ProductType,
            IsActive = dto.IsActive
        };

        var product = await _mediator.Send(command);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}
