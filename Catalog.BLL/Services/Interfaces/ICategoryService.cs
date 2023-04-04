using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.DAL.Models;

namespace Catalog.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        public Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        public Task<CategoryDto> AddCategoryAsync(CategoryDto category);
        public Task<CategoryDto> UpdateCategoryAsync(CategoryDto category);
        public Task DeleteCategoryAsync(int categoryId);
    }
}