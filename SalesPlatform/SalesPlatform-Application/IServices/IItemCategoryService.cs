using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Dtos.ItemCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPlatform_Application.IServices
{
    public interface IItemCategoryService
    {
        Task<ItemCategoryDto> CreateItemCategoryAsync(ItemCategoryDto itemCategoryDto);
        Task<IEnumerable<ItemCategoryDto>> GetAllItemCategoriesAsync();
        Task<IEnumerable<ItemDto>> GetItemsInCategoryAsync(int categoryId);
    }
}
