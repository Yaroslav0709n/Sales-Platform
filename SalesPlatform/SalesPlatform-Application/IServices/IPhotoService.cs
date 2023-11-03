using Microsoft.AspNetCore.Http;
using SalesPlatform_Application.Dtos;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.IServices
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoDto>> GetPhotosByItemIdAsync(int itemId);
        Task<IEnumerable<Photo>> UploadPhotosAsync(int itemId, List<IFormFile> files);
        Task<bool> UpdatePhotoAsync(int photoId, IFormFile newFile);
        Task<bool> DeletePhotoAsync(int photoId);
    }
}
