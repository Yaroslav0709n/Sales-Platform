using AutoMapper;
using SalesPlatform_Application.Dtos;
using SalesPlatform_Domain.Entities;

namespace SalesPlatform_Application.Mappings
{
    public class PhotoMapper:Profile
    {
        public PhotoMapper()
        {
            CreateMap<PhotoDto, Photo>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}
