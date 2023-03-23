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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items")]
        [SwaggerOperation("GetAllItems")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of all items.", typeof(List<Item>))]
        public IActionResult GetAllItems()
        {
            var items = _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet("items/{id}")]
        [SwaggerOperation("GetItemById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the item with the specified id.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item with the specified id is not found.")]
        public IActionResult GetItemById(int id)
        {
            var item = _itemService.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("items")]
        [SwaggerOperation("AddItem")]
        [SwaggerResponse(StatusCodes.Status201Created, "Creates a new Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public IActionResult AddItem([FromBody] ItemDto Item)
        {
            _itemService.AddItem(Item);
            return CreatedAtAction(nameof(GetItemById), new { id = Item.Id }, Item);
        }

        [HttpPut("items")]
        [SwaggerOperation("UpdateItem")]
        [SwaggerResponse(StatusCodes.Status201Created, "Updates a Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public IActionResult UpdateItem([FromBody] ItemDto Item)
        {
            _itemService.UpdateItem(Item);
            return CreatedAtAction(nameof(GetItemById), new { id = Item.Id }, Item);
        }

        [HttpDelete("items/{id}")]
        [SwaggerOperation("DeleteItem")]
        [SwaggerResponse(StatusCodes.Status201Created, "Deletes a Item.", typeof(Item))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Item data is invalid.")]
        public IActionResult DeleteItem([FromQuery] int id)
        {
            _itemService.DeleteItem(id);
            return Ok();
        }


    }
}