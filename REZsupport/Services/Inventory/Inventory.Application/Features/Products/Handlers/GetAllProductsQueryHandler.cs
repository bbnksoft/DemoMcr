using AutoMapper;
using Inventory.Application.Features.Products.Queries;
using Inventory.Application.Responses.Products;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Products.Handlers;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }
}
