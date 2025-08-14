using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AshAndEspresso.Models;

public class Category
{
    public Category()
    {
        Product = new Collection<Product>();
    }

    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    [JsonIgnore]
    public ICollection<Product> Product { get; set; }
}
