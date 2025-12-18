using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Merchandise;

namespace REZsupport.Application.Commands.Merchandise;

public class CreateMerchandiseCommand : IRequest<ApiResponse<MerchandiseDto>>
{
    public CreateMerchandiseDto Merchandise { get; set; } = null!;
}
