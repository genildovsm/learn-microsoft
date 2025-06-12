using apiCatalogo.Context;
using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    public sealed class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {        
        private readonly ApiCatalogoDbContext _context;

        
        public ProdutoRepository(ApiCatalogoDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtosParams"></param>
        /// <returns></returns>
        public PagedList<Produto> GetProdutos(ProdutosParameters produtosParams)
        {
            var produtos = GetAll().OrderBy(p => p.Id).AsQueryable();
            var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos, produtosParams.PageNumber, produtosParams.PageSize);

            return produtosOrdenados;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        public IEnumerable<Produto> GetProdutosPorCategoria(int id)
        {
            return GetAll().Where(c => c.CategoriaId == id);
        }
    }
}
