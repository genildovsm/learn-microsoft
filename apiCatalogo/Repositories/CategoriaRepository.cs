using apiCatalogo.Context;
using apiCatalogo.Models;

#pragma warning disable CS1591

namespace apiCatalogo.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        /// <summary>
        /// A palavra-chave "base" é usada para acessar membros de classe base 
        /// de dentro de uma classe derivada, no caso, o ocntexto da classe Repository
        /// </summary>
        /// <param name="context">Instância de Contexto da classe Repository</param>
        public CategoriaRepository(ApiCatalogoDbContext context) : base(context)
        {

        }
    }
}
