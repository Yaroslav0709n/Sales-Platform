using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SalesPlatform_Application.Extensions;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Photo> _photoRepository;
        private readonly IRepository<Item> _itemRepository;

        public PhotoService(IRepository<Photo> photoRepository,
                            IRepository<Item> itemRepository)
        {
            _photoRepository = photoRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Photo>> GetPhotosByItemIdAsync(int itemId)
        {
            var photos = await _photoRepository.Query()
                                               .Include(photo => photo.Item)
                                               .Where(photo => photo.ItemId == itemId)
                                               .ToListAsync();

            photos.ThrowIfNull(nameof(photos));

            return photos;      
        }

        public async Task<IEnumerable<Photo>> UploadPhotosAsync(int itemId, List<IFormFile> files)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);

            item.ThrowIfNull(nameof(item));

            var uploadedPhotos = new List<Photo>();

            foreach (var file in files)
            {
                byte[] imageData;
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    imageData = stream.ToArray();
                }

                var photo = new Photo
                {
                    ImageData = imageData,
                    Caption = "Image",
                    ItemId = item.Id
                };

                await _photoRepository.AddAsync(photo);
                await _photoRepository.SaveChangesAsync();

                uploadedPhotos.Add(photo);
            }

            return uploadedPhotos;
        }

        public async Task<bool> UpdatePhotoAsync(int photoId, IFormFile newFile)
        {
            var photoExist = await _photoRepository.GetByIdAsync(photoId);

            photoExist.ThrowIfNull(nameof(photoExist));

            byte[] newImageData;
            using (var stream = new MemoryStream())
            {
                await newFile.CopyToAsync(stream);
                newImageData = stream.ToArray();
            }

            photoExist.ImageData = newImageData; 

            await _photoRepository.UpdateAsync(photoExist);
            await _photoRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePhotoAsync(int photoId)
        {
            var photo = await _photoRepository.GetByIdAsync(photoId);

            photo.ThrowIfNull(nameof(photo));

            _photoRepository.Delete(photo);
            await _photoRepository.SaveChangesAsync();

            return true;
        }
    }
}
