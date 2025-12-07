using MediatR;
using Inventory.Application.Responses.Products;

namespace Inventory.Application.Features.Products.Commands;

public class UpdateProductCommand : IRequest<ProductResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; }
}
