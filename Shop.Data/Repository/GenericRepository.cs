using Microsoft.EntityFrameworkCore;
using Shop.Data.Persistence;

namespace Shop.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private readonly ShopDbContext _context;

    public GenericRepository(ShopDbContext context)
    {
        _context = context;
    }


    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }


    public T? GetById(int id)
    {
        return _context.Set<T>()
            .Find(id);
    }


    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }


    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }


    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
}