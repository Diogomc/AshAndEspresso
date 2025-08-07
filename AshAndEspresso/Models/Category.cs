using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AshAndEspresso.Models;

[Table("Categories")]
public class Category
{
    public Category()
    {
        Product = new Collection<Product>();
    }

    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Product> Product { get; set; }
}
