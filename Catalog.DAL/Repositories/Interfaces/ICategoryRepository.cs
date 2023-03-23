using System.Collections.Generic;
using Catalog.DAL.Models;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<CategoryDto> GetCategories();

        public CategoryDto GetCategoryById(int categoryId);

        public void AddCategory(CategoryDto category);

        public void UpdateCategory(CategoryDto category);

        public void DeleteCategory(int categoryId);
    }
}