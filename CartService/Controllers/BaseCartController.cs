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
    [Route("v{version:apiVersion}/[controller]/{cartId}/items")]
    public abstract class BaseCartController : ControllerBase
    {
        protected readonly ICartService _cartManager;

        public BaseCartController(ICartService cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add an item to a cart")]
        [SwaggerResponse(200, "The item was added successfully")]
        [SwaggerResponse(400, "The request was invalid")]
        public ActionResult AddItemAsync(string cartId, [FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _cartManager.AddItemAsync(cartId, item);
            return Ok();
        }

        [HttpDelete("{itemId}")]
        [SwaggerOperation(Summary = "Remove an item from a cart")]
        [SwaggerResponse(200, "The item was removed successfully")]
        [SwaggerResponse(404, "The item or cart was not found")]
        public ActionResult RemoveItemAsync(string cartId, int itemId)
        {
            _cartManager.RemoveItemAsync(cartId, itemId);
            return Ok();
        }

    }    
}