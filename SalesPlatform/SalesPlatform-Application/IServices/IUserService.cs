using SalesPlatform_Application.Dtos.Auth;
using SalesPlatform_Application.Dtos.User;

namespace SalesPlatform_Application.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string userId);
        Task<UserDto> GetCurrentUser();
        Task<UserDto> UpdateUserAsync(UpdateUserDto updateUser);
    }
}
