using SalesPlatform_Application.Dtos;
using SalesPlatform_Application.Dtos.Item;

namespace SalesPlatform_Application.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync(PaginationDto? paginationDto);
        Task<ItemDto> GetItemByIdAsync(int itemId);
        Task<IEnumerable<ItemDto>> GetItemsByUserIdAsync(string userId, PaginationDto? paginationDto);
        Task<ItemDto> CreateItemAsync(ItemDto itemDto, int categoryId);
        Task<ItemDto> UpdateItemAsync(UpdateItemDto itemDto);
        Task<bool> DeleteItemAsync(int itemId);
        Task<bool> IncreaseItemFavouritesAsync(int itemId);
        Task<bool> DecreaseItemFavouritesAsync(int itemId);
    }
}
