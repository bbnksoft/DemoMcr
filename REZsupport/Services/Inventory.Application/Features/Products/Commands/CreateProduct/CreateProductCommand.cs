using MediatR;
using AutoMapper;
using FluentValidation;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;

namespace Inventory.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductDto>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid SectionId { get; set; }
    public string? SKU { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public string? ProductType { get; set; }
    public bool IsActive { get; set; } = true;
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.SectionId).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.AvailableQuantity).GreaterThanOrEqualTo(0);
    }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Core.Entities.Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            SectionId = request.SectionId,
            SKU = request.SKU,
            Price = request.Price,
            AvailableQuantity = request.AvailableQuantity,
            ProductType = request.ProductType,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Products.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }
}
