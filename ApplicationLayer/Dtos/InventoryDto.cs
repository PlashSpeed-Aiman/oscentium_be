namespace ApplicationLayer.Dtos;

public class InventoryDto
{
    public int? Id { get; set; }
    public ItemDto? Item { get; set; }
    public int? Quantity { get; set; }
}