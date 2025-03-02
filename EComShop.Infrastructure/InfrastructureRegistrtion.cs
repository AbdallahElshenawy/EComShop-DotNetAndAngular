using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;
using EComShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EComShop.Infrastructure
{
    public static class InfrastructureRegistrtion
    {
        public static IServiceCollection InfrastructureConfiquration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("EComShop")); 
            });


            return services;
        }
    }
}
