using Microsoft.AspNetCore.Http;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.IServices
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotosByItemIdAsync(int itemId);
        Task<IEnumerable<Photo>> UploadPhotosAsync(int itemId, List<IFormFile> files);
        Task<bool> UpdatePhotoAsync(int photoId, IFormFile newFile);
        Task<bool> DeletePhotoAsync(int photoId);
    }
}
