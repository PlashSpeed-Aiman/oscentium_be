using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repository.Interface;

namespace InfrastructureLayer.Repository.Implementation;

public class ItemRepository : IItemRepository
{
    
    private readonly ApplicationContext _context;
    
    public ItemRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public Task<List<Item>> GetItemsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddItem(Item item)
    {
        await _context.Items.AddAsync(item);
    }

    public void UpdateItem(Item item)
    {
        throw new NotImplementedException();
    }

    public void DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public void PersistChanges()
    {
        _context.SaveChanges();
    }
}