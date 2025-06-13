using System.Linq.Expressions;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Interface genérica de acesso a dados
    /// </summary>
    /// <typeparam name="T">Entidade genérica</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Verifica se existe na entidade genérica e retorna um booleano
        /// </summary>
        /// <param name="predicado"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Obtém um registro da entidade genérica com base na chave primária
        /// </summary>
        /// <param name="id">Chave primária de T</param>
        T? Find(int id);

        /// <summary>
        /// Obter uma lista de todos os registros da entidade genérica
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Obter um registro da entidade genérica correspondente à expressão lambda
        /// </summary>
        /// <param name="predicado">Função lâmbda</param>
        Task<T?> GetAsync(Expression<Func<T, bool>> predicado); 

        /// <summary>
        /// Cria um novo registro na entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        T Create(T entity);

        /// <summary>
        /// Atualiza um registro na entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        T Update (T entity);

        /// <summary>
        /// Exclui um registro da entidade genérica
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        void Delete(T entity);
    }
}
