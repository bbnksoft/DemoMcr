using MediatR;
namespace Inventory.Application.Features.Venues.Commands;
public class DeleteVenueCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteVenueCommand(Guid id) { Id = id; }
}

//public class DeleteVenueCommandHandler : IRequestHandler<DeleteVenueCommand, Unit>
//{
//    private readonly IUnitOfWork _unitOfWork;

//    public DeleteVenueCommandHandler(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//    }

//    public async Task<Unit> Handle(DeleteVenueCommand request, CancellationToken cancellationToken)
//    {
//        var venue = await _unitOfWork.Venues.GetByIdAsync(request.Id, cancellationToken);
//        if (venue == null) throw new NotFoundException(nameof(Core.Entities.Venue), request.Id);

//        await _unitOfWork.Venues.DeleteAsync(venue, cancellationToken);
//        await _unitOfWork.SaveChangesAsync(cancellationToken);

//        return Unit.Value;
//    }
//}
