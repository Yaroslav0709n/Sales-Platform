using AutoMapper;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Dtos.ItemCategory;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.Mappings
{
    public class ItemCategoryMapper:Profile
    {
        public ItemCategoryMapper()
        {
            CreateMap<ItemCategoryDto, ItemCategory>();
            CreateMap<ItemCategory, ItemCategoryDto>();
        }
    }
}
