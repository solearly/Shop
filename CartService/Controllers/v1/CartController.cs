﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.DAL.Interfaces;
using CartService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CartService.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CartController : BaseCartController
    {
        public CartController(ICartService cartManager) : base(cartManager)
        {
        }
    
        [HttpGet]
        [SwaggerOperation(Summary = "Get all items in a cart")]
        [SwaggerResponse(200, "The items were found", typeof(Cart))]
        [SwaggerResponse(404, "The cart was not found")]
        public async Task<IActionResult> GetAsync(string cartId)
        {
            var items = await _cartManager.GetCartAsync(cartId);
            return Ok(items);
        }
    }
}