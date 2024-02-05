using DomainLayer.Entities;

namespace InfrastructureLayer.Repository.Interface;

public interface IInventoryRepository
{
    List<Inventory> GetInventory();
    
    Inventory? GetInventoryById(int id);
    List<Inventory> GetInventoriesByName(string name);
    Inventory AddInventory(Inventory inventory);
    Inventory UpdateInventory(Inventory inventory);
    void DeleteInventory(int id);
    void PersistChanges();
    
}