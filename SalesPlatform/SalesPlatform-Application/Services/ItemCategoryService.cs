using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Dtos.ItemCategory;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly IRepository<ItemCategory> _itemCategoryRepository;
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemCategoryService(IRepository<ItemCategory> itemCategoryRepository,
                                   IRepository<Item> itemRepository,       
                                   IMapper mapper)
        {
            _itemCategoryRepository = itemCategoryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemCategoryDto> CreateItemCategoryAsync(ItemCategoryDto itemCategoryDto)
        {
            var category = _mapper.Map<ItemCategory>(itemCategoryDto);
            await _itemCategoryRepository.AddAsync(category);
            await _itemCategoryRepository.SaveChangesAsync();
            return _mapper.Map<ItemCategoryDto>(category);
        }

        public async Task<IEnumerable<ItemCategoryDto>> GetAllItemCategoriesAsync()
        {
            var categories = await _itemCategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemCategoryDto>>(categories);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsInCategoryAsync(int categoryId)
        {
            var items = await _itemRepository.Query().Include(item => item.ItemCategory)
                                       .Where(item => item.ItemCategoryId == categoryId)
                                       .ToListAsync();

            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }
    }
}
