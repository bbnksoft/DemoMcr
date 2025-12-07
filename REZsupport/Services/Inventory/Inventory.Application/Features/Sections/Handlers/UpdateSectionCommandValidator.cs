using AutoMapper;
using FluentValidation;
using Inventory.Application.Features.Sections.Commands;
using Inventory.Application.Responses.Sections;
using Inventory.Core.Exceptions;
using Inventory.Core.Interfaces;
using MediatR;

namespace Inventory.Application.Features.Sections.Handlers;
public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, SectionResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SectionResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await _unitOfWork.Sections.GetByIdAsync(request.Id, cancellationToken);
        if (section == null) throw new NotFoundException(nameof(Core.Entities.Section), request.Id);

        section.Name = request.Name;
        section.Description = request.Description;
        section.VenueId = request.VenueId;
        section.Capacity = request.Capacity;
        section.RowCount = request.RowCount;
        section.SectionType = request.SectionType;
        section.IsActive = request.IsActive;
        section.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Sections.UpdateAsync(section, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SectionResponse>(section);
    }
}
public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.VenueId).NotEmpty();
        RuleFor(x => x.Capacity).GreaterThanOrEqualTo(0);
    }
}
