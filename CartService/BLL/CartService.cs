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

            public async Task<IList<Item>> GetItems(int cartId)
            {
                var cartItems = await _cartRepository.GetItems(cartId);
                return cartItems;
            }

            public async Task AddItem(int cartId, Item item)
            {
                await _cartRepository.Add(cartId, item);
            }

            public async Task RemoveItem(int cartId, int id)
            {
                await _cartRepository.Remove(cartId, id);
            }
        }
    }
}