using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetCategoriesAsync());
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            return _mapper.Map<CategoryDto>(await _categoryRepository.GetCategoryByIdAsync(categoryId));
        }

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            return _mapper.Map<CategoryDto>(await _categoryRepository.AddCategoryAsync(categoryEntity));
        }

        public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            return _mapper.Map<CategoryDto>(await _categoryRepository.UpdateCategoryAsync(categoryEntity));
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }
    }
}