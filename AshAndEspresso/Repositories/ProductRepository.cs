using AshAndEspresso.Context;
using AshAndEspresso.Models;
using AshAndEspresso.Pagination;

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
    public PagedList<Product> GetProductsParam(ProductsParameters productsParam)
    {
        var products = GetAll().OrderBy(p => p.ProductId).AsQueryable();
        var orderedProducts = PagedList<Product>.ToPagedList(products, productsParam.PageNumber, productsParam.PageSize);
        return orderedProducts;
    }
}
