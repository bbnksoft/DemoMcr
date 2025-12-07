using AutoMapper;
using Inventory.Application.DTOs;

namespace Inventory.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Venue mappings
        CreateMap<Core.Entities.Venue, VenueDto>();
        CreateMap<CreateVenueDto, Core.Entities.Venue>();
        CreateMap<UpdateVenueDto, Core.Entities.Venue>();

        // Section mappings
        CreateMap<Core.Entities.Section, SectionDto>();
        CreateMap<CreateSectionDto, Core.Entities.Section>();
        CreateMap<UpdateSectionDto, Core.Entities.Section>();

        // Product mappings
        CreateMap<Core.Entities.Product, ProductDto>();
        CreateMap<CreateProductDto, Core.Entities.Product>();
        CreateMap<UpdateProductDto, Core.Entities.Product>();
    }
}
