namespace ApplicationLayer.Dtos;

public class ItemDto
{
    public int? Id { get; set; }
    public string? SKU { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public double? Price { get; set; }
}