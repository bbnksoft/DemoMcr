using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;

namespace REZsupport.Application.Commands.Company;

public class UpdateCompanyCommand : IRequest<ApiResponse<CompanyDto>>
{
    public Guid CompanyId { get; set; }
    public UpdateCompanyDto Company { get; set; } = null!;
}
