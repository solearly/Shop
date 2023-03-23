using System.Collections.Generic;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemDto> GetItems()
        {
            return _itemRepository.GetItems();
        }

        public ItemDto GetItemById(int itemId)
        {
            return _itemRepository.GetItemById(itemId);
        }

        public void AddItem(ItemDto item)
        {
            _itemRepository.AddItem(item);
        }

        public void UpdateItem(ItemDto item)
        {
            _itemRepository.UpdateItem(item);
        }

        public void DeleteItem(int itemId)
        {
            _itemRepository.DeleteItem(itemId);
        }
    }
}