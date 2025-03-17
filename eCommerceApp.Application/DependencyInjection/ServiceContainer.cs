using eCommerceApp.Application.Implementation;
using eCommerceApp.Application.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping.MappingConfig));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
