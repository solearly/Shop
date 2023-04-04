using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartService
    {
        Task AddItem(int cartId, Item item);
        Task RemoveItem(int cartId, int itemId);
        Task<IList<Item>> GetItems(int cartId);
    }
}