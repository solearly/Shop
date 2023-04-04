using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.DAL.Models;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int categoryId);

        public Task<Category> AddCategoryAsync(Category category);

        public Task<Category> UpdateCategoryAsync(Category category);

        public Task DeleteCategoryAsync(int categoryId);
    }
}