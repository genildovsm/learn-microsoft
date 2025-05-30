using apiCatalogo.Models;

#pragma warning disable CS1591

namespace apiCatalogo.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorCategoria(int id);
    }
}
