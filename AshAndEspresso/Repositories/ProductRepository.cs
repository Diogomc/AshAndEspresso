using AshAndEspresso.Context;
using AshAndEspresso.Models;

namespace AshAndEspresso.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext repository) : base(repository)
    {
    }

    public IEnumerable<Product> GetProductCategory(int id)
    {
        return GetAll().Where(c => c.CategoryId == id);
    }
}
