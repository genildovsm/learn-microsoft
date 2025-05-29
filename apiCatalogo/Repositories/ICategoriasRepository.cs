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
        Task AtualizarCategoriaAsync(Categoria categoria);

        /// <summary>
        /// Cria uma categoria
        /// </summary>
        /// <param name="categoria">Instância da entidade Categoria</param>
        Task<Categoria> CriarCategoriaAsync(Categoria categoria);

        /// <summary>
        /// Excluir uma categoria
        /// </summary>
        /// <param name="categoria">Instância da entidade Categoria</param>
        Task DeleteCategoriaAsync(Categoria categoria);

        /// <summary>
        /// Obtém uma lista de categorias
        /// </summary>
        IQueryable<Categoria> ObterCategoriasProdutos();

        /// <summary>
        /// Obtém uma categoria correspondente ao Id informado
        /// </summary>
        /// <param name="id">Id da categoria</param>
        Task<Categoria?> ObterCategoriaPorIdAsync(int id);        
    }
}
