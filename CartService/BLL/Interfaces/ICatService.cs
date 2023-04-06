using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartService
    {
        Task AddItemAsync(string cartId, Item item);
        Task RemoveItemAsync(string cartId, int itemId);
        Task<IList<Item>> GetItemsAsync(string cartId);
        Task<Cart> GetCartAsync(string cartId);
    }
}