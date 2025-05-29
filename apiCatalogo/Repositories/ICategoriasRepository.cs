using apiCatalogo.Models;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Interface de acesso a dados de Categoria
    /// </summary>
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="categoria">Instância da entidade Categoria</param>
        Task CategoriaUpdateAsync(Categoria categoria);

        /// <summary>
        /// Cria uma categoria
        /// </summary>
        /// <param name="categoria">Instância da entidade Categoria</param>
        Task<Categoria> CategoriaCreateAsync(Categoria categoria);

        /// <summary>
        /// Excluir uma categoria
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        Task<bool> CategoriaDeleteAsync(int id);

        /// <summary>
        /// Obtém uma lista de categorias
        /// </summary>
        IQueryable<Categoria> CategoriasProdutosGetAll();

        /// <summary>
        /// Obtém uma categoria correspondente ao Id informado
        /// </summary>
        /// <param name="id">Id da categoria</param>
        Task<Categoria?> CategoriaGetByIdAsync(int id);        
    }
}
