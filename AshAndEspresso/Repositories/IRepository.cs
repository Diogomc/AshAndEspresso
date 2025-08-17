using System.Linq.Expressions;

namespace AshAndEspresso.Repositories;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetId(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Delete(T entity);
    T Update(T entity);
}
