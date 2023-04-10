using System.Threading.Tasks;
using CartService.DAL.Interfaces;
using CartService.Models;

namespace CartService.DAL
{
    using CartingService.DAL;
    using System.Collections.Generic;
    using System.Linq;

    namespace CartingService.BLL
    {
        public class CartService : ICartService
        {
            private readonly ICartRepository _cartRepository;

            public CartService(ICartRepository cartRepository)
            {
                _cartRepository = cartRepository;
            }

            public async Task<Cart> GetCartAsync(string cartId)
            {
                var cartItems = await _cartRepository.GetItemsAsync(cartId);
                var cart = new Cart
                {
                    Id = cartId,
                    Items = cartItems
                };
                return cart;
            }

            public async Task<IList<Item>> GetItemsAsync(string cartId)
            {
                var cartItems = await _cartRepository.GetItemsAsync(cartId);
                return cartItems;
            }

            public async Task AddItemAsync(string cartId, Item item)
            {
                await _cartRepository.AddAsync(cartId, item);
            }

            public async Task RemoveItemAsync(string cartId, int id)
            {
                await _cartRepository.RemoveAsync(cartId, id);
            }
        }
    }
}