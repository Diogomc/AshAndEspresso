using AshAndEspresso.Models;
using AshAndEspresso.Pagination;

namespace AshAndEspresso.Repositories;

public interface IProductRepository : IRepository<Product>
{
    PagedList<Product> GetProductsParam(ProductsParameters productsParams);
    IEnumerable<Product> GetProductCategory(int id);
}
