using apiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

#pragma warning disable 1591 
#pragma warning disable IDE0290

namespace apiCatalogo.Repositories
{    
    public class Repository<T> : IRepository<T> where T : class
    {
        
        protected readonly ApiCatalogoDbContext _context;
        
        public Repository(ApiCatalogoDbContext context)
        {
            _context = context;
        }
        
        public bool Any(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Any(predicado);
        }
        
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T? Get(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>()
                .FirstOrDefault(predicado);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
