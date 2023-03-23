using System.Collections.Generic;
using Catalog.DAL.Models;

namespace Catalog.BLL.Services.Interfaces
{
    public interface IItemService
    {
        public IEnumerable<ItemDto> GetItems();
        public ItemDto GetItemById(int itemId);
        public void AddItem(ItemDto item);
        public void UpdateItem(ItemDto item);
        public void DeleteItem(int itemId);
    }
}