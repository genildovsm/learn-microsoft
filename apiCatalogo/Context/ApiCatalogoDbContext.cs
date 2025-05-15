using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context;

public class ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiCatalogoDbContext).Assembly);
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos {get; set;}
}
