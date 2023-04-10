using AutoMapper;
using Catalog.DAL.Models;

namespace Catalog.Entities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Item, ItemDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ItemDto, Item>();
        }
    }
}