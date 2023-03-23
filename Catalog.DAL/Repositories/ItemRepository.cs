using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CatalogDbContext _dbContext;
        private readonly IMapper _mapper;

        public ItemRepository(CatalogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ItemDto> GetItems()
        {
            var list = _dbContext.Items.ToList();
            return _mapper.Map<List<ItemDto>>(list);
        }

        public ItemDto GetItemById(int itemId)
        {
            var item = _dbContext.Items.Find(itemId);
            return _mapper.Map<ItemDto>(item);
        }

        public void AddItem(ItemDto item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            _dbContext.Items.Add(itemEntity);
            _dbContext.SaveChanges();
        }

        public void UpdateItem(ItemDto item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            _dbContext.Items.Update(itemEntity);
            _dbContext.SaveChanges();
        }

        public void DeleteItem(int itemId)
        {
            var item = _dbContext.Items.Find(itemId);
            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();
        }
    }
}
