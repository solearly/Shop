using System;
using System.Collections.Generic;
using CartService.DAL.Interfaces;
using CartService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartService.Controllers
{

[ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartManager;

        public CartController(ICartService cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost("{cartId}/items")]
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

        [HttpDelete("{cartId}/items/{itemId}")]
        [SwaggerOperation(Summary = "Remove an item from a cart")]
        [SwaggerResponse(200, "The item was removed successfully")]
        [SwaggerResponse(404, "The item or cart was not found")]
        public ActionResult RemoveItem(int cartId, int itemId)
        {
            _cartManager.RemoveItem(cartId, itemId);
            return Ok();
        }

        [HttpGet("{cartId}/items")]
        [SwaggerOperation(Summary = "Get all items in a cart")]
        [SwaggerResponse(200, "The items were found", typeof(List<Item>))]
        [SwaggerResponse(404, "The cart was not found")]
        public ActionResult<List<Item>> GetItems(int cartId)
        {
            var items = _cartManager.GetItems(cartId);
            return Ok(items);
        }
    }    
}