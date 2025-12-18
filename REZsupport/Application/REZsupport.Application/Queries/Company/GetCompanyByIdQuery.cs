using MediatR;
using REZsupport.Application.DTOs.Common;
using REZsupport.Application.DTOs.Company;

namespace REZsupport.Application.Queries.Company;
public class GetCompanyByIdQuery : IRequest<ApiResponse<CompanyDto>>
{
    public Guid CompanyId { get; set; }
    public Guid? TenantId { get; set; }
}
