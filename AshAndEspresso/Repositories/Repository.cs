using AshAndEspresso.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AshAndEspresso.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    public readonly AppDbContext _context;
    public Repository (AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetId(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate);
    }

    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
        return entity;
    }

  
    public T Update(T entity)
    {
        _context.Set<T>().Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}
