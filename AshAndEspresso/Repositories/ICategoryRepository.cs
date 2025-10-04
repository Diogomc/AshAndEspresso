using AshAndEspresso.Models;
using AshAndEspresso.Pagination;

namespace AshAndEspresso.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    PagedList<Category> GetCategoriesParam(CategoriesParameters categoriesParams);
}
