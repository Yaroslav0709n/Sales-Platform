using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesPlatform_Application.IServices;

namespace SalesPlatform_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetPhotosByItemId(int itemId)
        {
            var photos = await _photoService.GetPhotosByItemIdAsync(itemId);

            return Ok(photos);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> UploadPhotos(int itemId, List<IFormFile> files)
        {
            var photos = await _photoService.UploadPhotosAsync(itemId, files);

            return Ok(true);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> UpdatePhoto(int photoId, IFormFile file)
        {
            var photo = await _photoService.UpdatePhotoAsync(photoId, file);

            return Ok(true);
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var photo = await _photoService.DeletePhotoAsync(photoId);

            return Ok(true);
        }
    }
}
