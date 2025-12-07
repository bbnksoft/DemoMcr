using MediatR;
using Microsoft.AspNetCore.Mvc;
using Inventory.Application.DTOs;
using Inventory.Application.Features.Products.Commands.CreateProduct;
using Inventory.Application.Features.Products.Commands.UpdateProduct;
using Inventory.Application.Features.Products.Commands.DeleteProduct;
using Inventory.Application.Features.Products.Queries.GetProductById;
using Inventory.Application.Features.Products.Queries.GetAllProducts;

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
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto)
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
    public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] UpdateProductDto dto)
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
