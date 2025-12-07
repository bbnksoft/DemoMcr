using MediatR;
using Inventory.Core.Interfaces;
using Inventory.Core.Exceptions;

namespace Inventory.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteProductCommand(Guid id) { Id = id; }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
        if (product == null) throw new NotFoundException(nameof(Core.Entities.Product), request.Id);

        await _unitOfWork.Products.DeleteAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
