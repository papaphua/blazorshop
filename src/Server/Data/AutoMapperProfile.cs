using AutoMapper;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Dtos;

namespace BlazorShop.Server.Data;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        
        CreateMap<Category, CategoryDto>();

        CreateMap<RegisterDto, User>()
            .ForSourceMember(src => src.Password,
                opt => opt.DoNotValidate())
            .ForSourceMember(src => src.ConfirmPassword,
                opt => opt.DoNotValidate());

        CreateMap<User, ProfileDto>();
        CreateMap<ProfileDto, User>();

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryId));


        CreateMap<ProductDto, Product>()
            .ForMember(
                dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.CategoryId));
    }
}