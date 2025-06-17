using apiCatalogo.Context;
using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    ///
    public sealed class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProdutoRepository(ApiCatalogoDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtém uma lista paginada de produtos
        /// </summary>
        /// <param name="produtosParams">Parâmetros</param>
        /// <returns></returns>
        public async Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParams)
        {
            var produtos = await GetAllAsync();
            var produtosOrdenados = produtos.OrderBy(p => p.Id).AsQueryable();
            var resultado = PagedList<Produto>.ToPagedList(produtosOrdenados, produtosParams.PageNumber, produtosParams.PageSize);

            return resultado;
        }

        /// <summary>
        /// Obtém uma lista de produtos com base no filtro
        /// </summary>
        /// <param name="produtoFiltroParams">Parãmetros</param>
        /// <returns></returns>
        public async Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoFiltroParams)
        {
            var produtos = await GetAllAsync();

            if (produtoFiltroParams.Preco.HasValue && !string.IsNullOrEmpty(produtoFiltroParams.PrecoCriterio))
            {
                switch (produtoFiltroParams.PrecoCriterio.ToLower())
                {
                    case "maior":
                        produtos = produtos.Where(p => p.Valor > produtoFiltroParams.Preco.Value).OrderBy(p => p.Valor);
                        break;

                    case "menor":
                        produtos = produtos.Where(p => p.Valor < produtoFiltroParams.Preco.Value).OrderBy(p => p.Valor);
                        break;

                    case "igual":
                        produtos.Where(p => p.Valor == produtoFiltroParams.Preco.Value).OrderBy(p => p.Valor);
                        break;
                }

            }

            var produtosFiltrados = PagedList<Produto>.ToPagedList(produtos.AsQueryable(), produtoFiltroParams.PageNumber, produtoFiltroParams.PageSize);

            return produtosFiltrados;
        }

        /// <summary>
        /// Obtém uma lista de produtos com base no Id da categoria
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        public async Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id)
        {
            var produtos = await GetAllAsync();
            var produtosCategoria = produtos.Where(c => c.CategoriaId == id);

            return produtosCategoria;
        }
    }
}
