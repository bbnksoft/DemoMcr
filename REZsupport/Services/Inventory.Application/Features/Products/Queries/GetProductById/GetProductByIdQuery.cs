using MediatR;
using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
    public GetProductByIdQuery(Guid id) { Id = id; }
}

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product == null) throw new NotFoundException(nameof(Core.Entities.Product), request.Id);

        return _mapper.Map<ProductDto>(product);
    }
}
