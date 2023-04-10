using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [SwaggerOperation(nameof(GetAllCategoriesAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "List of all categories.", typeof(IList<Category>))]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(nameof(GetCategoryByIdAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the category with the specified id.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category with the specified id is not found.")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [SwaggerOperation(nameof(AddCategoryAsync))]
        [SwaggerResponse(StatusCodes.Status201Created, "Creates a new category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryDto category)
        {
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { id = category.Id }, category);
        }

        [HttpPut]
        [SwaggerOperation(nameof(UpdateCategoryAsync))]
        [SwaggerResponse(StatusCodes.Status201Created, "Updates a category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryDto category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return CreatedAtAction("GetCategoryById", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(nameof(DeleteCategory))]
        [SwaggerResponse(StatusCodes.Status201Created, "Deletes a category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public async Task<IActionResult> DeleteCategory([FromQuery] int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }


    }
}