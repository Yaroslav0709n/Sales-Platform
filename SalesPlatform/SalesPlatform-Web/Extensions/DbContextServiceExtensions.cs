using Microsoft.EntityFrameworkCore;
using SalesPlatform_Infrastructure.Context;

namespace SalesPlatform_Web.Extensions
{
    public static class DbContextServiceExtensions
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MSSQL"), 
                                                        b => b.MigrationsAssembly("SalesPlatform-Web")));
            return services;
        }
    }
}
