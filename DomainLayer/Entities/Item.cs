using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities;

public class Item
{
    [Key]
    public int? Id { get; set; }
    public string? SKU { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public double? Price { get; set; }
    
    public int InventoryId { get; set; } // Foreign key
    public virtual Inventory? Inventory { get; set; } // Navigation property
    
    public static Item Create(int? id, string? sku, string? name, string? category, double? price)
    {
        return new Item
        {
            Id = id,
            SKU = sku,
            Name = name,
            Category = category,
            Price = price
        };
    }
    
}