using AutoMapper;
using Inventory.Application.Responses.Products;
using Inventory.Application.Responses.Sections;
using Inventory.Application.Responses.Venues;
using Inventory.Core.Entities;

namespace Inventory.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Venue mappings
        CreateMap<Venue, VenueResponse>();
        CreateMap<CreateVenueResponse, Venue>();
        CreateMap<UpdateVenueResponse, Venue>();

        // Section mappings
        CreateMap<Section, SectionResponse>();
        CreateMap<CreateSectionResponse, Section>();
        CreateMap<UpdateSectionResponse, Section>();

        // Product mappings
        CreateMap<Product, ProductResponse>();
        CreateMap<CreateProductResponse, Product>();
        CreateMap<UpdateProductResponse, Product>();
    }
}
