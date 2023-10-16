using SalesPlatform_Domain.Entities.Identity;

namespace SalesPlatform_Application.IServices
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user);
    }
}
