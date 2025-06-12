using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {        
        /// <param name="produtosParams">Parâmetros</param>
        /// <returns></returns>
        PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);
        
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
