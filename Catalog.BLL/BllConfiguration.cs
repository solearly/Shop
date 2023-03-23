using Catalog.BLL.Services;
using Catalog.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.BLL
{
    public static class BllConfiguration
    {
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IItemService, ItemService>();
        }
    }
}