using System.Collections.Generic;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public void AddCategory(CategoryDto category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(CategoryDto category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}