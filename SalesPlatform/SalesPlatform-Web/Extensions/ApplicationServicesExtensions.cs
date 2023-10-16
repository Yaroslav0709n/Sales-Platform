using SalesPlatform_Application.IServices;
using SalesPlatform_Application.Services;

namespace SalesPlatform_Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
