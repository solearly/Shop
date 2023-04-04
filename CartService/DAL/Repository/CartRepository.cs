using System.Threading.Tasks;
using CartService.DAL.Interfaces;
using CartService.Models;

namespace CartService.DAL
{
    using LiteDB;
    using System.Collections.Generic;
    using System.Linq;

    namespace CartingService.DAL
    {
        public class CartRepository : ICartRepository
        {
            private readonly LiteDatabase _db;

            public CartRepository(LiteDatabase db)
            {
                _db = db;
            }

            public async Task<IList<Item>> GetItems(int cartId)
            {
                var cartItems = _db.GetCollection<Item>("Cart")
                    .FindAll()
                    .Where(x => x.CartId == cartId)
                    .ToList();
                return await Task.FromResult<IList<Item>>(cartItems);
            }

            public async Task Add(int cartId, Item item)
            {
                item.CartId = cartId;
                var cartItems = _db.GetCollection<Item>("Cart");
                cartItems.Insert(item);
                await Task.CompletedTask;
            }

            public async Task Remove(int cartId, int itemId)
            {
                var cartItems = _db.GetCollection<Item>("Cart");
                cartItems.Delete(itemId);
                await Task.CompletedTask;
            }
        }
    }
}