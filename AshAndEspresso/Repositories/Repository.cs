using AshAndEspresso.Context;
using Microsoft.EntityFrameworkCore;

namespace AshAndEspresso.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _repository;

    public Repository(AppDbContext repository)
    {
        _repository = repository;
    }

    public IEnumerable<T> GetAll()
    {
        return _repository.Set<T>().AsNoTracking().ToList();
    }
    public T Delete(T entity)
    {
        _repository.Set<T>().Remove(entity);
        return entity;
    }

    public T? GetId(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _repository.Set<T>().FirstOrDefault(predicate);
    }

    public T Update(T entity)
    {
        _repository.Set<T>().Update(entity);
        return entity;
    }
    public T Create(T entity)
    {
        _repository.Set<T>().Add(entity);
        return entity;
    }

}
