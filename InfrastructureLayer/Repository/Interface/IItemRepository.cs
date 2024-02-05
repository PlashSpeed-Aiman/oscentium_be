using DomainLayer.Entities;

namespace InfrastructureLayer.Repository.Interface;

public interface IItemRepository
{
    Task<List<Item>> GetItemsAsync();
    Task AddItem(Item item);
    void UpdateItem(Item item);
    void DeleteItem(int id);
    void PersistChanges();
}