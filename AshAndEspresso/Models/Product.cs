using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AshAndEspresso.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImageUrl { get; set; }
    public int? AvailableQuantity { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Categories { get; set; }
}
