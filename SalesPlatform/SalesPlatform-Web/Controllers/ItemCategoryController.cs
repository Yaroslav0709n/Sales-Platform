using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.Dtos.ItemCategory;
using SalesPlatform_Application.IServices;

namespace SalesPlatform_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetAllItemCategories()
        {
            var categories = await _itemCategoryService.GetAllItemCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categoryId"), Authorize]
        public async Task<ActionResult> GetItemsInCategory(int categoryId)
        {
            var categories = await _itemCategoryService.GetItemsInCategoryAsync(categoryId);

            return Ok(categories);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> CreateItemCategory(ItemCategoryDto itemCategoryDto)
        {
            var category = await _itemCategoryService.CreateItemCategoryAsync(itemCategoryDto);

            return Ok(true); 
        }
    }
}
