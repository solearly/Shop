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

            public List<Item> GetItems(int cartId)
            {
                var cartItems = _cartRepository.GetItems(cartId);
                return cartItems;
            }

            public void AddItem(int cartId, Item item)
            {
                _cartRepository.Add(cartId, item);
            }

            public void RemoveItem(int cartId, int id)
            {
                _cartRepository.Remove(cartId, id);
            }
        }
    }
}