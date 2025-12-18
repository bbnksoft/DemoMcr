using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;

namespace REZsupport.Application.Commands.Company;

public class CreateCompanyCommand : IRequest<ApiResponse<CompanyDto>>
{
    public CreateCompanyDto Company { get; set; } = null!;
}
