namespace DomainLayer.Entities;

public class ItemImage
{
    public int? Id { get; set; }
    public string? ImageUrl { get; set; }
    public int? ItemId { get; set; }
    public virtual Item? Item { get; set; }
}