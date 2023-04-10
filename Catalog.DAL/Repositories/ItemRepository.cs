using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ItemRepository(CatalogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(int categoryId, int page, int pageSize)
        {
            var list = await _dbContext.Items
                .Where(x => x.CategoryId == categoryId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return list;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var item = await _dbContext.Items.FindAsync(itemId);
            return item;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            _dbContext.Items.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            _dbContext.Items.Update(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            var item = _dbContext.Items.Find(itemId);
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
