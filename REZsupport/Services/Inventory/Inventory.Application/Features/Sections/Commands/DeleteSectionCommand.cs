using MediatR;
namespace Inventory.Application.Features.Sections.Commands;

public class DeleteSectionCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public DeleteSectionCommand(Guid id) { Id = id; }
}