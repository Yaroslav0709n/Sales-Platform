using AutoMapper;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.Mappings
{
    public class ItemMapper:Profile
    {
        public ItemMapper()
        {
            CreateMap<ItemDto, Item>();
            CreateMap<Item, ItemDto>();

            CreateMap<UpdateItemDto, Item>();
            CreateMap<Item, UpdateItemDto>();
        }
    }
}
