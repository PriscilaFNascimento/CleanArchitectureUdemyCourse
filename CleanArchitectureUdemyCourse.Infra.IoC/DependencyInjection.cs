using CleanArchitectureUdemyCourse.Domain.Repositories;
using CleanArchitectureUdemyCourse.Infra.Data.Context;
using CleanArchitectureUdemyCourse.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureUdemyCourse.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(
                                                  configuration.GetConnectionString("DefaultConnection"),
                                                  b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

    }
}
