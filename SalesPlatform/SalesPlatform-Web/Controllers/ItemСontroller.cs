using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.Dtos;
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
        public async Task<ActionResult> GetAllItems([FromQuery] PaginationDto? paginationDto)
        {
            var items = await _itemService.GetAllItemsAsync(paginationDto);
            
            return Ok(items);
        }

        [HttpGet("currentUser"), Authorize]
        public async Task<ActionResult> GetCurrentUserItems([FromQuery] PaginationDto? paginationDto)
        {
            var items = await _itemService.GetCurrentUserItemsAsync(paginationDto);

            return Ok(items);
        }


        [HttpGet("itemId"), Authorize]
        public async Task<ActionResult> GetItemById(int itemId)
        {
            var items = await _itemService.GetItemByIdAsync(itemId);

            return Ok(items);
        }

        [HttpGet("userId"), Authorize]        
        public async Task<ActionResult> GetItemByUserId(string userId, [FromQuery] PaginationDto? paginationDto)
        {
            var item = await _itemService.GetItemsByUserIdAsync(userId, paginationDto);

            return Ok(item);
        }

        [HttpPost("categoryId"), Authorize]
        public async Task<ActionResult> CreateItem(ItemDto itemDto, int categoryId)
        {
            var isCreated = await _itemService.CreateItemAsync(itemDto, categoryId);

            return Ok(isCreated);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> UpdateItem(UpdateItemDto updateItemDto)
        {
            var item = await _itemService.UpdateItemAsync(updateItemDto);

            return Ok(item);
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var isTrue = await _itemService.DeleteItemAsync(id);

            return Ok(isTrue);
        }

        [HttpPut("increase"), Authorize]
        public async Task<ActionResult> IncreaseItemFavourites(int itemId)
        {
            var isTrue = await _itemService.IncreaseItemFavouritesAsync(itemId);

            return Ok(isTrue);
        }

        [HttpPut("decrease"), Authorize]
        public async Task<ActionResult> DecreaseItemFavourites(int itemId)
        {
            var isTrue = await _itemService.DecreaseItemFavouritesAsync(itemId);

            return Ok(isTrue);
        }
    }
}
