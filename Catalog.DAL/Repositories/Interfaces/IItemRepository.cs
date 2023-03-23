using System.Collections.Generic;
using Catalog.DAL.Models;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public IEnumerable<ItemDto> GetItems();

        public ItemDto GetItemById(int itemId);

        public void AddItem(ItemDto item);

        public void UpdateItem(ItemDto item);

        public void DeleteItem(int itemId);
    }
}