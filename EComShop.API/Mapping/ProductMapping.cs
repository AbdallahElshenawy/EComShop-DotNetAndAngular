using AutoMapper;
using EComShop.Core.Dtos;
using EComShop.Core.Entities.Product;

namespace EComShop.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                 .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                 .ForMember(x => x.Price, opt => opt.MapFrom(src => src.NewPrice)) // Map NewPrice to Price
                 .ReverseMap();

            CreateMap<Photo, PhotoDTO>()
                .ReverseMap();

            CreateMap<AddProductDTO, Product>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore());

            CreateMap<Product, AddProductDTO>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore());

            CreateMap<UpdateProductDTO, Product>()
               .ForMember(dest => dest.Photos, opt => opt.Ignore());

            CreateMap<Product, UpdateProductDTO>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore());

        }
    }
}