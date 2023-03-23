using System.Collections.Generic;
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

        [HttpGet("categories")]
        [SwaggerOperation("GetAllCategories")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of all categories.", typeof(List<Category>))]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        [SwaggerOperation("GetCategoryById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the category with the specified id.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category with the specified id is not found.")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("categories")]
        [SwaggerOperation("AddCategory")]
        [SwaggerResponse(StatusCodes.Status201Created, "Creates a new category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public IActionResult AddCategory([FromBody] CategoryDto category)
        {
            _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut("categories")]
        [SwaggerOperation("UpdateCategory")]
        [SwaggerResponse(StatusCodes.Status201Created, "Updates a category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public IActionResult UpdateCategory([FromBody] CategoryDto category)
        {
            _categoryService.UpdateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpDelete("categories/{id}")]
        [SwaggerOperation("DeleteCategory")]
        [SwaggerResponse(StatusCodes.Status201Created, "Deletes a category.", typeof(Category))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Category data is invalid.")]
        public IActionResult DeleteCategory([FromQuery] int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }


    }
}