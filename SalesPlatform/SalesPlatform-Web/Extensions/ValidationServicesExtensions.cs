using FluentValidation;
using SalesPlatform_Application.Dtos.Auth;
using SalesPlatform_Application.Dtos.Item;
using SalesPlatform_Application.Validation;

namespace SalesPlatform_Web.Extensions
{
    public static class ValidationServicesExtensions
    {
        public static IServiceCollection AddValidationService(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterDto>, RegisterUserValidator>();
            services.AddTransient<IValidator<ItemDto>, ItemValidator>();
            services.AddTransient<IValidator<UpdateItemDto>, UpdateItemValidator>();

            return services;
        }
    }
}
