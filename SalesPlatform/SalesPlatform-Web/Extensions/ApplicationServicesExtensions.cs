using SalesPlatform_Application.IServices;
using SalesPlatform_Application.Services;
using SalesPlatform_Domain.Entities.Identity;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();

            return services;
        }
    }
}
