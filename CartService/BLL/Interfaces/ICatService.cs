using System.Collections.Generic;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartService
    {
        void AddItem(int cartId, Item item);
        void RemoveItem(int cartId, int itemId);
        List<Item> GetItems(int cartId);
    }
}