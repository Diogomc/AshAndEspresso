using AshAndEspresso.Context;
using AshAndEspresso.Models;
using AshAndEspresso.Pagination;

namespace AshAndEspresso.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext repository) : base(repository)
    {
    }

    public PagedList<Category> GetCategoriesParam(CategoriesParameters categoriesParams)
    {
        var categories = GetAll().OrderBy(c => c.CategoryId).AsQueryable();
        var orderedCategories = PagedList<Category>.ToPagedList(categories, categoriesParams.PageNumber, categoriesParams.PageSize);

        return orderedCategories;
    }
}
