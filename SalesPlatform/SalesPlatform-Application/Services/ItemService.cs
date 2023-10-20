using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SalesPlatform_Application.Dtos;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Extensions;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IPaginationService _paginationService;
        private readonly IMapper _mapper;

        public ItemService(IRepository<Item> itemRepository,
                           IHttpContextAccessor contextAccessor,
                           IPaginationService paginationService,
                           IMapper mapper)
        {
            _itemRepository = itemRepository;
            _contextAccessor = contextAccessor;
            _paginationService = paginationService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync(PaginationDto? paginationDto)
        {
            var items = await _itemRepository.GetAllAsync();

            items.ThrowIfNull(nameof(items));

            return _mapper.Map<IEnumerable<ItemDto>>(_paginationService.GetItemsByPagination(items, paginationDto));
        }

        public async Task<ItemDto> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            item.CountViews++;
            await _itemRepository.SaveChangesAsync();
            return _mapper.Map<ItemDto>(item);
        }

        public async Task<IEnumerable<ItemDto>> GetItemsByUserIdAsync(string userId, PaginationDto? paginationDto)
        {
            var items = await _itemRepository.Query()
                                            .Include(item => item.ItemCategory)
                                            .Where(item => item.ApplicationUserId == userId)
                                            .ToListAsync();

            items.ThrowIfNull(nameof(items));

            return _mapper.Map<IEnumerable<ItemDto>>(_paginationService.GetItemsByPagination(items, paginationDto));
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

        public async Task<ItemDto> UpdateItemAsync(UpdateItemDto itemDto)
        {
            var itemExist = await _itemRepository.Query()
                                            .FirstOrDefaultAsync(item => item.Id == itemDto.Id);

            itemExist.ThrowIfNull(nameof(itemExist));

            itemExist.Name = itemDto.Name;
            itemExist.Description = itemDto.Description;
            itemExist.State = itemDto.State;
            itemExist.Price = itemDto.Price;

            var item = await _itemRepository.UpdateAsync(itemExist);
            await _itemRepository.SaveChangesAsync();

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            _itemRepository.Delete(item);
            await _itemRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IncreaseItemFavouritesAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            item.Favourites++;
            await _itemRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DecreaseItemFavouritesAsync(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            item.Favourites--;
            await _itemRepository.SaveChangesAsync();

            return true;
        }
    }
}
