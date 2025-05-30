using apiCatalogo.Context;
using apiCatalogo.Models;

namespace apiCatalogo.Repositories
{
    /// <summary>  
    /// Repositório de acesso a dados de Categoria  
    /// </summary>  
    /// <remarks>  
    /// A palavra-chave "base" é usada para acessar membros de classe base   
    /// de dentro de uma classe derivada, no caso, o contexto da classe Repository  
    /// </remarks>  
    public class CategoriaRepository(ApiCatalogoDbContext context) : Repository<Categoria>(context), ICategoriaRepository
    {

    }
}
