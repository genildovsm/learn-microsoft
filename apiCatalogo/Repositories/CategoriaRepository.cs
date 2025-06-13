using apiCatalogo.Context;
using apiCatalogo.Models;
using apiCatalogo.Pagination;

namespace apiCatalogo.Repositories
{
    /// <summary>  
    /// Repositório de acesso a dados de Categoria  
    /// </summary>  
    /// <remarks>  
    /// A palavra-chave "base" é usada para acessar membros de classe base   
    /// de dentro de uma classe derivada, no caso, o contexto da classe Repository  
    /// </remarks>  
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public CategoriaRepository(ApiCatalogoDbContext context) : base(context)
        {

        }
         
        /// <summary>
        /// Retorna as categorias paginadas
        /// </summary>
        /// <param name="categoriasParams">Parâmetros de paginação</param>
        public async Task<PagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams)
        {
            var categorias = await GetAllAsync();
            var categoriasOrdenadas = categorias.OrderBy(c => c.Id).AsQueryable();
            var resultado = PagedList<Categoria>.ToPagedList(categoriasOrdenadas, categoriasParams.PageNumber, categoriasParams.PageSize);

            return resultado;
        }

        /// <summary>
        /// Retorna as categorias paginadas com base no filtro
        /// </summary>
        /// <param name="categoriasParams"></param>
        /// <returns></returns>
        public async Task<PagedList<Categoria>> GetCategoriasFiltroNomeAsync(CategoriasFiltroNome categoriasParams)
        {
            var categorias = await GetAllAsync();            

            if (!string.IsNullOrEmpty(categoriasParams.Nome))
            {
                categorias = categorias.Where(c => c.Nome.Contains(categoriasParams.Nome));
            }

            var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias.AsQueryable(), categoriasParams.PageNumber, categoriasParams.PageSize);

            return categoriasFiltradas;
        }
    }
}
