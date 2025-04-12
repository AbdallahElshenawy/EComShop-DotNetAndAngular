using AutoMapper;
using EComShop.Core.Dtos;
using EComShop.Core.Entities.Product;

namespace EComShop.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
