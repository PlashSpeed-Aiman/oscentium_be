using DomainLayer.Entities;
using InfrastructureLayer.Repository.Interface;

namespace ApplicationLayer.Service;

public class ItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public ItemService(IItemRepository itemRepository, IInventoryRepository inventoryRepository)
    {
        _itemRepository = itemRepository;
        _inventoryRepository = inventoryRepository;
    }
    
    public async Task<List<Item>> GetItemsAsync()
    {
        return await _itemRepository.GetItemsAsync();
    }
    
    public async Task AddItem(Item item)
    {
        item.Id = null;
        /*await _itemRepository.AddItem(item);
        _itemRepository.PersistChanges();*/
        
        _inventoryRepository.AddInventory(Inventory.Create(
            id: null,
            item: item,
            quantity: 0
        ));
        
        _inventoryRepository.PersistChanges();
        
    }
    
    public void UpdateItem(Item item)
    {
        _itemRepository.UpdateItem(item);
    }
    
    public void DeleteItem(int id)
    {
        _itemRepository.DeleteItem(id);
    }
}