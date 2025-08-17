using AshAndEspresso.Models;

namespace AshAndEspresso.Repositories;

public interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetProductCategory(int id);
}
