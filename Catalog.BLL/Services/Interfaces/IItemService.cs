using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.DAL.Models;

namespace Catalog.BLL.Services.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<ItemDto>> GetItemsAsync();
        public Task<ItemDto> GetItemByIdAsync(int itemId);
        public Task<ItemDto> AddItemAsync(ItemDto item);
        public Task<ItemDto> UpdateItemAsync(ItemDto item);
        public Task DeleteItemAsync(int itemId);
    }
}