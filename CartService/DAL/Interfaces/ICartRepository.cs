using System.Collections.Generic;
using CartService.Models;

namespace CartService.DAL.Interfaces
{
    public interface ICartRepository
    {
        public List<Item> GetItems(int cartId);
        public void Add(int cartId, Item item);
        public void Remove(int cartId, int itemId);
    }
}