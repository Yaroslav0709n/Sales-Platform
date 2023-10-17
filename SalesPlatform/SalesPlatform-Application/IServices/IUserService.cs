using SalesPlatform_Application.Dtos.Auth;

namespace SalesPlatform_Application.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string userId);
    }
}
