using AutoMapper;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Data;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>();

        CreateMap<RegisterDto, User>()
            .ForSourceMember(src => src.Password,
                opt => opt.DoNotValidate())
            .ForSourceMember(src => src.ConfirmPassword,
                opt => opt.DoNotValidate());

        CreateMap<User, ProfileDto>();
    }
}