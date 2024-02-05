using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities;

public class Sale
{
    [Key]
    public int? Id { get; set; }
    public ICollection<SaleItem>? SaleItems { get; set; }
    public double? Total { get; set; }
    public DateTime? Date { get; set; }
    
    // static factory method
    
    public static Sale Create(int? id, ICollection<SaleItem>? saleItems, double? total, DateTime? date)
    {
        return new Sale
        {
            Id = id,
            SaleItems = saleItems,
            Total = total,
            Date = date
        };
    }
    
    
   
}