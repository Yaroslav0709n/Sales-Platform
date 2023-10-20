using SalesPlatform_Application.Dtos;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.Services
{
    public class PaginationService : IPaginationService
    {
        public IEnumerable<Item> GetItemsByPagination(IEnumerable<Item> items, PaginationDto? paginationDto)
        {
            if (paginationDto is null || (paginationDto.Count == 0 && paginationDto.PageNumber == 0))
            {
                return items;
            }
            var countArticles = paginationDto.Count;
            var pageNumber = paginationDto.PageNumber;
            if (!items.Any() || items.Count() <= countArticles)
            {
                return items;
            }
            if (items.Count() < countArticles * pageNumber)
            {
                throw new ArgumentException(nameof(Item), paginationDto.ToString());
            }
            if (items.Skip(countArticles * pageNumber).Count() < countArticles)
            {
                return items.Skip(countArticles * pageNumber - 1).ToArray();
            }
            return items.Skip(countArticles * pageNumber).Take(countArticles).ToArray();
        }
    }
}

