using AutoMapper;
using Inventory.Application.Features.Products.Queries;
using Inventory.Application.Responses.Products;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Products.Handlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product == null) throw new NotFoundException(nameof(Core.Entities.Product), request.Id);

        return _mapper.Map<ProductResponse>(product);
    }
}
