using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Repository.Implementation;

public class InventoryRepository : IInventoryRepository
{
    private readonly ApplicationContext _context;

    public InventoryRepository(ApplicationContext context)
    {
        _context = context;
    }
    public List<Inventory> GetInventory()
    {
        return _context.Inventories.
            Include(x => x.Item)
            .ToList();
    }

    public List<Inventory> GetInventoriesByName(string name)
    {
        throw new NotImplementedException();
    }

    public Inventory? GetInventoryById(int id)
    {
        return _context.Inventories.FirstOrDefault(x => x.Id == id);
    }

    public Inventory AddInventory(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        return inventory;
    }

    public Inventory UpdateInventory(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
        return inventory;
    }

    public void DeleteInventory(int id)
    {
        var inventory = _context.Inventories.FirstOrDefault(x => x.Id == id);
        if (inventory == null)
        {
            throw new Exception("Inventory not found");
        }
      
        _context.Inventories.Remove(inventory);
    }

    public void PersistChanges()
    {
        _context.SaveChanges();
    }
}