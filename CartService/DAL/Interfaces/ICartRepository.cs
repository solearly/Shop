using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartRepository
    {
        public Task<IList<Item>> GetItemsAsync(string cartId);
        public Task AddAsync(string cartId, Item item);
        public Task RemoveAsync(string cartId, int itemId);
    }
}