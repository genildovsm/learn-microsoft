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
        /// 
        /// </summary>
        /// <param name="categoriasParams"></param>
        /// <returns></returns>
        PagedList<Categoria> GetCategorias (CategoriasParameters categoriasParams);  
    }
}
