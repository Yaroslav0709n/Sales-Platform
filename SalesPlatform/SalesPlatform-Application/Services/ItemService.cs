using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Extensions;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Infrastructure.Repositories;
using System.Collections.Generic;

namespace SalesPlatform_Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public ItemService(IRepository<Item> itemRepository,
                           IHttpContextAccessor contextAccessor,
                           IMapper mapper)
        {
            _itemRepository = itemRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto> GetItemByUserIdAsync(string userId)
        {
            var item = await _itemRepository.Query()
                                            .Include(item => item.ItemCategory)
                                            .FirstOrDefaultAsync(item => item.ApplicationUserId == userId);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto> CreateItemAsync(ItemDto itemDto, int categoryId)
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();
            
            var createItem = _mapper.Map<Item>(itemDto);
            createItem.Time = DateTime.Now;
            createItem.ApplicationUserId = userId;
            createItem.ItemCategoryId = categoryId;

            await _itemRepository.AddAsync(createItem);
            await _itemRepository.SaveChangesAsync();

            return _mapper.Map<ItemDto>(createItem);
        }
    }
}
