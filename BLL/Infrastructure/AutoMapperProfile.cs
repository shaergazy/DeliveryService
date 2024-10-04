using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();
            CreateMap<Category, ListCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, EditProductDto>().ReverseMap();
            CreateMap<Product, ListProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();

            CreateMap<Address, AddAddressDto>().ReverseMap();
            CreateMap<Address, EditAddressDto>().ReverseMap();
            CreateMap<Address, ListAddressDto>().ReverseMap();
            CreateMap<Address, GetAddressDto>().ReverseMap();

            CreateMap<PaymentMethod, PaymentMethodDto>().ReverseMap();
        }
    }
}