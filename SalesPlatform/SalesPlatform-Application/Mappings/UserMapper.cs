using AutoMapper;
using SalesPlatform_Application.Dtos.Auth;
using SalesPlatform_Application.Dtos.User;
using SalesPlatform_Domain.Entities.Identity;

namespace SalesPlatform_Application.Mappings
{
    public class UserMapper:Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();

            CreateMap<UpdateUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UpdateUserDto>();
        }
    }
}
