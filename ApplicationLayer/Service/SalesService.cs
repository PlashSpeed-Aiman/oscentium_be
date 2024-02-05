using DomainLayer.Entities;
using InfrastructureLayer.Repository.Interface;

namespace ApplicationLayer.Service;

public class SalesService
{
    private readonly ISalesRepository _salesRepository;
    
    public SalesService(ISalesRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }
    
    public async Task<List<Sale>> GetSalesAsync()
    {
        return await _salesRepository.GetSalesAsync();
    }
    
    public void AddSales(Sale sales)
    {
        var res = Sale.Create(
            id: null,
            saleItems: sales.SaleItems ?? throw new Exception("SaleItems is required."),
            total: sales.Total ?? default,
            date: sales.Date ?? throw new Exception("Date is required.")
        );
            
        _salesRepository.AddSale(res);
        _salesRepository.PersistChanges();
    }

    public void DeleteSales(int id)
    {
        _salesRepository.DeleteSale(id);
        _salesRepository.PersistChanges();
    }   
}