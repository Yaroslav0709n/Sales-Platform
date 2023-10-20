using SalesPlatform_Application.IServices;
using SalesPlatform_Application.Services;
using SalesPlatform_Domain.Entities;
using SalesPlatform_Domain.Entities.Identity;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Web.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepository<ApplicationUser>, Repository<ApplicationUser>>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IItemCategoryService, ItemCategoryService>();
            services.AddScoped<IRepository<ItemCategory>, Repository<ItemCategory>>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IRepository<Photo>, Repository<Photo>>();
            services.AddScoped<IPaginationService, PaginationService>();

            return services;
        }
    }
}
