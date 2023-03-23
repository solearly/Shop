using Catalog.DAL.Repositories;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.DAL
{
    public static class DalConfiguration
    {
        public static void AddDalRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
        }
    }
}