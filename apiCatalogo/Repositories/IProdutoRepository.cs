using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {
        /// <summary>
        /// Obtém uma lista de produtos paginados
        /// </summary>
        /// <param name="produtosParams">Parâmetros</param>
        /// <returns></returns>
        Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParams);

        /// <summary>
        /// Obtém uma lista paginada de produtos com base no filtro
        /// </summary>
        /// <param name="produtoFiltroParams">Parâmetros</param>
        Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoFiltroParams);
        
        /// <summary>
        /// Obtém uma lista de produtos com base no Id da categoria 
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns></returns>
        Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);
    }
}
 