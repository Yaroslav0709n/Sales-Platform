using SalesPlatform_Application.Dtos.Item;

namespace SalesPlatform_Application.IServices
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync();
        Task<ItemDto> GetItemByIdAsync(int itemId);
        Task<ItemDto> GetItemByUserIdAsync(string userId);
        Task<ItemDto> CreateItemAsync(ItemDto itemDto, int categoryId);
    }
}
