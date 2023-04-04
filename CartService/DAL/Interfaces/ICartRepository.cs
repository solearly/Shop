using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartRepository
    {
        public Task<IList<Item>> GetItems(int cartId);
        public Task Add(int cartId, Item item);
        public Task Remove(int cartId, int itemId);
    }
}