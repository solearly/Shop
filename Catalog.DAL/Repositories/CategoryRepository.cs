using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(CatalogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            return _mapper.Map<CategoryDto>(category);
        }

        public void AddCategory(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _dbContext.Categories.Add(categoryEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _dbContext.Categories.Update(categoryEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}
