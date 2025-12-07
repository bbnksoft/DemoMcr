using Inventory.Application.Features.Sections.Commands;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Sections.Handlers;
public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSectionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await _unitOfWork.Sections.GetByIdAsync(request.Id, cancellationToken);
        if (section == null) throw new NotFoundException(nameof(Core.Entities.Section), request.Id);

        await _unitOfWork.Sections.DeleteAsync(section, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
