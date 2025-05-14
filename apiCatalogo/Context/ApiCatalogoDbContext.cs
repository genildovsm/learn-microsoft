using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context;

public class ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos {get; set;}
}
