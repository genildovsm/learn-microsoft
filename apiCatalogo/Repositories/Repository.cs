using apiCatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Repositório genérico de acesso a dados
    /// </summary>
    /// <typeparam name="T">Classe genérica</typeparam>
    /// <remarks>
    /// Construtor da classe
    /// </remarks>
    /// <param name="context">Instância do contexto</param>
    public class Repository<T>(ApiCatalogoDbContext context) : IRepository<T> where T : class
    {
        /// <summary>
        /// Instância do contexto de acesso a dados
        /// </summary>
        protected readonly ApiCatalogoDbContext _context = context;

        /// <summary>
        /// Verifica se existe e retorna um booleano
        /// </summary>
        /// <param name="predicado">Expressão lambda</param>
        /// <returns>Retorna um valor booleano</returns>
        public bool Any(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>().Any(predicado);
        }

        /// <summary>
        /// Adiciona um novo registro na entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        /// <returns>Retorna uma instância da classe genérica criada</returns>
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        /// <summary>
        /// Deleta um registro da entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtém um registro da entidade genérica com base na chave primária
        /// </summary>
        /// <param name="id">Chave primária da entidade genérica</param>
        /// <returns></returns>
        public T? Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Obtém o primeiro resultado que corresponde à expressão lambda fornecida
        /// </summary>
        /// <param name="predicado">Expressão lambda</param>
        public T? Get(Expression<Func<T, bool>> predicado)
        {
            return _context.Set<T>()
                .FirstOrDefault(predicado);
        }

        /// <summary>
        /// Obtem todos os registros da entidade genérica
        /// </summary>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Atualiza um registro da entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        public T Update(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                _context.Set<T>().Update(entity);
            }
            else if (entry.State == EntityState.Added || entry.State == EntityState.Unchanged)
            {
                entry.State = EntityState.Modified;
            }

            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}
