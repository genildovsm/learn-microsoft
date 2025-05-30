using apiCatalogo.Context;
using apiCatalogo.Models;

#pragma warning disable CS1591

namespace apiCatalogo.Repositories
{
    public sealed class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {        
        private new readonly ApiCatalogoDbContext _context;

        public ProdutoRepository(ApiCatalogoDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return GetAll().Where(c => c.CategoriaId == id);
        }
    }
}
