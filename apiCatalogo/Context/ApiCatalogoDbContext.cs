using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context;

/// <summary>
/// Classe de configuração do contexto
/// </summary>
/// <param name="options"></param>
public class ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Configuração das classes de mapeamento no contexto
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiCatalogoDbContext).Assembly);
    }

}
