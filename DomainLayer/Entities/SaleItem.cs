using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities;

public class SaleItem
{
    [Key]
    public int? Id { get; set; }
    [ForeignKey(nameof(Sale))]
    
    public int? SaleId { get; set; }
    public virtual Sale? Sale { get; set; }
    [ForeignKey(nameof(Item))]
    public int? ItemId { get; set; }
    public virtual Item? Item { get; set; }
    public int? Quantity { get; set; }
    public double? PricePerUnit { get; set; }
    
    
    
    public static SaleItem Create(int id, int saleId, Sale sale, int itemId, Item item, int quantity, double pricePerUnit)
    {
        return new SaleItem
        {
            Id = id,
            SaleId = saleId,
            Sale = sale,
            ItemId = itemId,
            Item = item,
            Quantity = quantity,
            PricePerUnit = pricePerUnit
        };
    }
    
    public static SaleItem Create(int? id, int? saleId, int? itemId, int? quantity, double? pricePerUnit)
    {
        return new SaleItem
        {
            Id = id,
            SaleId = saleId,
            ItemId = itemId,
            Quantity = quantity,
            PricePerUnit = pricePerUnit
        };
    }
    
}