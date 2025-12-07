using AutoMapper;
using FluentValidation;
using Inventory.Application.Features.Products.Commands;
using Inventory.Application.Responses.Products;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Products.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product == null) throw new NotFoundException(nameof(Core.Entities.Product), request.Id);

        product.Name = request.Name;
        product.Description = request.Description;
        product.SectionId = request.SectionId;
        product.SKU = request.SKU;
        product.Price = request.Price;
        product.AvailableQuantity = request.AvailableQuantity;
        product.ProductType = request.ProductType;
        product.IsActive = request.IsActive;
        product.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductResponse>(product);
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.SectionId).NotEmpty();
        RuleFor(x => x.Price).GreaterThan(0);
    }
}
