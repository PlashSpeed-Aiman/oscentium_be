using System.Text.Json.Serialization;
using DomainLayer.Entities;

namespace ApplicationLayer.Dtos.Sale;


public class SaleDto
{
    public ICollection<SaleItemDto> SaleItems { get; set; }
    public double? Total { get; set; }
    public DateTime? Date { get; set; }
}