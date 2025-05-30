using apiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Classe genérica
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Instância do contexto
        /// </summary>
        protected readonly ApiCatalogoDbContext _context;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public Repository(ApiCatalogoDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Verifica se existe
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Any(predicado);
        }

        /// <summary>
        /// Criar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        /// <summary>
        /// Deleta
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consulta
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>()
                .FirstOrDefault(predicado);
        }

        /// <summary>
        /// Consulta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Atualiza
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
