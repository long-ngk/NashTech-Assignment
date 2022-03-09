using General.DataAccess.Business.Interfaces;
using General.DataAccess.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace General.DataAccess.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductImageService, ProductImageService>();
        }
    }
}
