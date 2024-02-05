using DomainLayer.Entities;

namespace InfrastructureLayer.Repository.Interface;

public interface ISalesRepository
{
    Task<List<Sale>> GetSalesAsync();
    Task AddSale(Sale sale);
    void UpdateSale(Sale sale);
    void DeleteSale(int id);
    void PersistChanges();
    
}