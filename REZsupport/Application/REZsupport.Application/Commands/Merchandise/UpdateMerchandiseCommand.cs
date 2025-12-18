using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Merchandise;

namespace REZsupport.Application.Commands.Merchandise;

public class UpdateMerchandiseCommand : IRequest<ApiResponse<MerchandiseDto>>
{
    public Guid MerchandiseId { get; set; }
    public UpdateMerchandiseDto Merchandise { get; set; } = null!;
}
