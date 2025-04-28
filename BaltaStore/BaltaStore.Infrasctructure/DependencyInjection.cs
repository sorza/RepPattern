using BaltaStore.Domain.Abstractions;
using BaltaStore.Domain.Repositories;
using BaltaStore.Infrasctructure.Data;
using BaltaStore.Infrasctructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaltaStore.Infrasctructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
