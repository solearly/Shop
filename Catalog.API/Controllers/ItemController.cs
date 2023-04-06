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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{categoryId}/{page}/{pageSize}")]
        [SwaggerOperation(nameof(GetAllItemsAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "List of all items.", typeof(IList<Item>))]
        public async Task<IActionResult> GetAllItemsAsync([FromRoute] int categoryId, [FromRoute] int page, [FromRoute] int pageSize)
        {
            var items = await _itemService.GetItemsAsync(categoryId, page, pageSize);
            return Ok(items);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(nameof(GetItemByIdAsync))]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the item with the specified id.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item with the specified id is not found.")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [SwaggerOperation(nameof(AddItemAsync))]
        [SwaggerResponse(StatusCodes.Status201Created, "Creates a new Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public async Task<IActionResult> AddItemAsync([FromBody] ItemDto item)
        {
            await _itemService.AddItemAsync(item);
            return CreatedAtAction("GetItemById", new { id = item.Id }, item);
        }

        [HttpPut]
        [SwaggerOperation(nameof(UpdateItemAsync))]
        [SwaggerResponse(StatusCodes.Status201Created, "Updates a Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] ItemDto item)
        {
            await _itemService.UpdateItemAsync(item);
            return CreatedAtAction("GetItemById", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(nameof(DeleteItemAsync))]
        [SwaggerResponse(StatusCodes.Status201Created, "Deletes a Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public async Task<IActionResult> DeleteItemAsync([FromQuery] int id)
        {
            await _itemService.DeleteItemAsync(id);
            return Ok();
        }


    }
}