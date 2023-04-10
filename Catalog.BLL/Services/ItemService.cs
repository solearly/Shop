using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(int categoryId, int page, int pageSize)
        {
            return _mapper.Map<List<ItemDto>>(await _itemRepository.GetItemsAsync(categoryId, page, pageSize));
        }

        public async Task<ItemDto> GetItemByIdAsync(int itemId)
        {
            return  _mapper.Map<ItemDto>(await _itemRepository.GetItemByIdAsync(itemId));
        }

        public async Task<ItemDto> AddItemAsync(ItemDto item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            return _mapper.Map<ItemDto>(await _itemRepository.AddItemAsync(itemEntity));
        }

        public async Task<ItemDto> UpdateItemAsync(ItemDto item)
        {
            var itemEntity = _mapper.Map<Item>(item);
            return _mapper.Map<ItemDto>(await _itemRepository.UpdateItemAsync(itemEntity));
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _itemRepository.DeleteItemAsync(itemId);
        }
    }
}