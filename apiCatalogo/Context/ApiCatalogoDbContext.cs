using apiCatalogo.Models;
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
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiCatalogoDbContext).Assembly);
    }

    /// <summary>
    /// Configuração da entidade Categoria
    /// </summary>
    public DbSet<Categoria> Categorias { get; set; }

    /// <summary>
    /// Configuração da entidade Produto
    /// </summary>
    public DbSet<Produto> Produtos { get; set; }
}
