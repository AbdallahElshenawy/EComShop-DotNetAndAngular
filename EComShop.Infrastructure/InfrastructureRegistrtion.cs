using EComShop.Core.Interfaces;
using EComShop.Core.Services;
using EComShop.Infrastructure.Data;
using EComShop.Infrastructure.Repositories;
using EComShop.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace EComShop.Infrastructure
{
    public static class InfrastructureRegistrtion
    {
        public static IServiceCollection InfrastructureConfiquration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IImageManagementService, ImageManagementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine
                (Directory.GetCurrentDirectory(),"wwwroot")));

            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("EComShop")); 
            });


            return services;
        }
    }
}
