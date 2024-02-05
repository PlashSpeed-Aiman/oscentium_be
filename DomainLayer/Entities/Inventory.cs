using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities;

public class Inventory
{
    [Key]
    public int? Id { get; set; }
    
    public virtual Item? Item { get; set; } // Navigation property
    public int? Quantity { get; set; }

    public static Inventory Create(int? id, Item item, int quantity)
    {
        return new Inventory
        {
            Id = id,
            Item = item,
            Quantity = quantity
        };
    }
}