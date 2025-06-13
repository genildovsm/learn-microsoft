using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Interface de acesso a dados de Categoria
    /// </summary>
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        /// <summary>
        /// Obtém uma lista paginada de categorias
        /// </summary>
        /// <param name="categoriasParams">Parâmetros</param>
        /// <returns></returns>
        Task<PagedList<Categoria>> GetCategoriasAsync (CategoriasParameters categoriasParams);

        /// <summary>
        /// Obtém uma lista paginada de categorias com base no filtro
        /// </summary>
        /// <param name="categoriasParams">Parâmetros</param>
        /// <returns></returns>
        Task<PagedList<Categoria>> GetCategoriasFiltroNomeAsync (CategoriasFiltroNome categoriasParams);
    }
}
