using ApplicationLayer.Dtos.Sale;
using ApplicationLayer.Service;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2;

[Route("api/[controller]/[action]")]
public class SalesController:Controller
{
    private readonly SalesService _salesService;
    
    public SalesController(SalesService salesService)
    {
        _salesService = salesService;
    }
    
    [HttpGet]
    public async  Task<IActionResult> GetSales()
    {
        var res =await _salesService.GetSalesAsync();
        return Ok(res);
    }
    
    [ProducesResponseType(200, Type = typeof(SaleDto))]
    [HttpPost]
    public IActionResult AddSales([FromBody] SaleDto sale)
    {
        var saleItems = sale.SaleItems.Select(x => SaleItem.Create(
            id: null,
            itemId: x.ItemId,
            saleId: null,
            quantity: x.Quantity,
            pricePerUnit: x.PricePerUnit
            )).ToList();
        var res = Sale.Create(
            id: null,
            saleItems: saleItems,
            total: sale.Total,
            date: sale.Date
        );
        
        _salesService.AddSales(res);
        return Ok();
    }
    
}