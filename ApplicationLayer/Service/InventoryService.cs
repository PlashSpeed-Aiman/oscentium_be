using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Repository.Interface;

namespace ApplicationLayer.Service;

public class InventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    
    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    

    public List<Inventory> GetInventory()
    {
       return _inventoryRepository.GetInventory();
    }
    
    public void AddInventory(Inventory inventory)
    {
        var res= Inventory.Create(
            id: inventory.Id ?? default,
            item: inventory.Item,
            quantity: inventory.Quantity ?? default
        );
            
        _inventoryRepository.AddInventory(res);
        _inventoryRepository.PersistChanges();
    }
    public void UpdateInventory(UpdateInventoryDto dto)
    {
        var inventory = _inventoryRepository.GetInventoryById(dto.Id);
        if (inventory == null)
        {
            throw new Exception("Inventory not found");
        }
        inventory.Quantity = dto.Quantity;
        _inventoryRepository.UpdateInventory(inventory);
        _inventoryRepository.PersistChanges();
    }
   

    public void DeleteInventory(int id)
    {
        _inventoryRepository.DeleteInventory(id);
        _inventoryRepository.PersistChanges();
    }
}