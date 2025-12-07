using MediatR;
using Inventory.Application.Responses.Products;

namespace Inventory.Application.Features.Products.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponse>> { }
