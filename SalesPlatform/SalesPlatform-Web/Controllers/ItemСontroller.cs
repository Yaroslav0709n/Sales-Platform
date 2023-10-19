using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.IServices;

namespace SalesPlatform_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemСontroller : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemСontroller(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            
            return Ok(items);
        }

        [HttpGet("itemId"), Authorize]
        public async Task<ActionResult> GetItemById(int itemId)
        {
            var items = await _itemService.GetItemByIdAsync(itemId);

            return Ok(items);
        }

        [HttpGet("userId"), Authorize]        
        public async Task<ActionResult> GetItemByUserId(string userId)
        {
            var item = await _itemService.GetItemByUserIdAsync(userId);

            return Ok(item);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> CreateItem(ItemDto itemDto, int categoryId)
        {
            var item = await _itemService.CreateItemAsync(itemDto, categoryId);

            return Ok(true);
        }
    }
}
