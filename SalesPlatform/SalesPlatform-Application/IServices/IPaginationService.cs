using SalesPlatform_Application.Dtos;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.IServices
{
    public interface IPaginationService
    {
        IEnumerable<Item> GetItemsByPagination(IEnumerable<Item> items, PaginationDto? paginationDto);
    }
}
