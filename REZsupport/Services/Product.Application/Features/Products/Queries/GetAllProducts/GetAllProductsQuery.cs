using MediatR;
using Product.Application.DTOs;

namespace Product.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{
}
