using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.DAL.Models;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetItemsAsync(int categoryId, int page, int pageSize);

        public Task<Item> GetItemByIdAsync(int itemId);

        public Task<Item> AddItemAsync(Item item);

        public Task<Item> UpdateItemAsync(Item item);

        public Task DeleteItemAsync(int itemId);
    }
}