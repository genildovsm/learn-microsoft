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
        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParams)
        {
            var categorias = GetAll().OrderBy(c => c.Id).AsQueryable();

            var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias, categoriasParams.PageNumber, categoriasParams.PageSize);

            return categoriasOrdenadas;
        }
    }
}
