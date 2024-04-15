using AutoMapper;
using CleanArcMvc.Application.DTOs;
using CleanArcMvc.Application.Products.Commands;

namespace CleanArcMvc.Application.Mappings;

public class DTOToDomainMappingProfile : Profile
{
    public DTOToDomainMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
