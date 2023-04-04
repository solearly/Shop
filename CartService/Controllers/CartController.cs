using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.DAL.Interfaces;
using CartService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartService.Controllers
{

[ApiController]
    [Route("[controller]/{cartId}/items")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartManager;

        public CartController(ICartService cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add an item to a cart")]
        [SwaggerResponse(200, "The item was added successfully")]
        [SwaggerResponse(400, "The request was invalid")]
        public ActionResult AddItem(int cartId, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _cartManager.AddItem(cartId, item);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        [SwaggerOperation(Summary = "Remove an item from a cart")]
        [SwaggerResponse(200, "The item was removed successfully")]
        [SwaggerResponse(404, "The item or cart was not found")]
        public ActionResult RemoveItem(int cartId, int itemId)
        {
            _cartManager.RemoveItem(cartId, itemId);
            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all items in a cart")]
        [SwaggerResponse(200, "The items were found", typeof(IList<Item>))]
        [SwaggerResponse(404, "The cart was not found")]
        public async Task<IActionResult> GetItems(int cartId)
        {
            var items = await _cartManager.GetItems(cartId);
            return Ok(items);
        }
    }    
}