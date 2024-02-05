using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repository.Interface;

namespace InfrastructureLayer.Repository.Implementation;

public class SalesRepository : ISalesRepository
{
    readonly ApplicationContext _context;
    
    public SalesRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Sale>> GetSalesAsync()
    {
        var res = await _context.Set<Sale>()
            .Include(x => x.SaleItems)
            .ToListAsync();
        return res;
    }

    public async Task AddSale(Sale sale)
    {
        await _context.Sales.AddAsync(sale);
    }

    public void UpdateSale(Sale sale)
    {
         _context.Sales.Update(sale);
    }

    public void DeleteSale(int id)
    {
        var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
        if (sale == null)
        {
            throw new Exception("Sale not found");
        }
      
        _context.Sales.Remove(sale);
    }

    public void PersistChanges()
    {
        _context.SaveChanges();
    }
}