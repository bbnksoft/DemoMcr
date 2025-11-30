using AutoMapper;
using Product.Application.DTOs;

namespace Product.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Entities.Product, ProductDto>();
        CreateMap<CreateProductDto, Core.Entities.Product>();
        CreateMap<UpdateProductDto, Core.Entities.Product>();
    }
}
