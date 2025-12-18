using MediatR;
using REZsupport.Application.DTOs.Common;

namespace REZsupport.Application.Commands.Company;

public class DeleteCompanyCommand : IRequest<ApiResponse<bool>>
{
    public Guid CompanyId { get; set; }
}
