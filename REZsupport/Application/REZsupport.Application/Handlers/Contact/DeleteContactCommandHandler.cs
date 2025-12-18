using MediatR;
using REZsupport.Application.Commands.Contact;
using REZsupport.Application.DTOs.Common;
using REZsupport.Core.Interfaces;

namespace REZsupport.Application.Handlers.Contact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ApiResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var contact = await _unitOfWork.Contacts.GetByIdAsync(request.ContactId, cancellationToken);

            if (contact == null)
            {
                return ApiResponse<bool>.ErrorResponse("Contact not found.");
            }

            //// Check for dependencies
            //var hasReservations = await _context.Reservations
            //    .AnyAsync(r => r.PrimaryContactId == request.ContactId, cancellationToken);

            //if (hasReservations)
            //{
            //    return ApiResponse<bool>.ErrorResponse("Cannot delete contact with existing reservations. Consider deactivating instead.");
            //}

            await _unitOfWork.Contacts.DeleteAsync(contact, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ApiResponse<bool>.SuccessResponse(true, "Contact deleted successfully.");
        }
        catch (Exception ex)
        {
            return ApiResponse<bool>.ErrorResponse($"Error deleting contact: {ex.Message}");
        }
    }
}
