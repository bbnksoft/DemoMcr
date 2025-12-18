using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.Merchandise;

public class DeleteMerchandiseCommand : IRequest<ApiResponse<bool>>
{
    public Guid MerchandiseId { get; set; }
}
