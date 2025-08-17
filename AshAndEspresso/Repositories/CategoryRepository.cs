using AshAndEspresso.Context;
using AshAndEspresso.Models;

namespace AshAndEspresso.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext repository) : base(repository)
    {
    }
}
