using System.Linq.Expressions;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Interface genérica de acesso a dados
    /// </summary>
    /// <typeparam name="T">Classe genérica</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obter uma lista dos registros de T
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Obter um registro de T correspondente à expressão lâmbda fornecida
        /// </summary>
        /// <param name="predicado">Função lâmbda. Ex: _repo.Get(x => x.Id == id)</param>
        T? Get(Expression<Func<T,bool>> predicado);

        /// <summary>
        /// Cria um novo registro de T
        /// </summary>
        /// <param name="entity"></param>
        T Create(T entity);

        /// <summary>
        /// Atualiza um registro de T
        /// </summary>
        /// <param name="entity"></param>
        T Update (T entity);

        /// <summary>
        /// Exclui um registro de T correspondente ao Id informado
        /// </summary>
        /// <param name="entity"></param>
        T Delete(T entity);
    }
}
