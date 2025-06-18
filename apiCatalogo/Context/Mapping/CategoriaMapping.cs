using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context.Mapping;

/// <summary>
/// Classe de mapeamento
/// </summary>
public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    /// <summary>
    /// Mapeamento dos atributos da entidade Categoria
    /// </summary>
    /// <param name="b"></param>
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Categoria> b)
    {
        b.ToTable("tbCategorias");

        b.HasKey(x => x.Id);

        b.Property(x => x.Nome)
        .HasColumnName("nmCategoria")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

        b.Property(x => x.ImagemUrl)
        .HasColumnName("imUrl")
        .HasColumnType("varchar")
        .HasMaxLength(255);

        b.Property(x => x.CreatedAt)
            .HasColumnName("createdAt")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        b.Property(x => x.UpdatedAt)
            .HasColumnName("updatedAt")
            .HasColumnType("datetime");

        b.HasIndex(x => x.Nome, "ix_categorias_nome");

        b.HasMany(x => x.Produtos)
            .WithOne(c => c.Categoria)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasData(
            new { Id = 1, Nome = "Cosméticos", ImagemUrl = "cosmeticos.jpg", CreatedAt = DateTime.Now },
            new { Id = 2, Nome = "Eletrônicos", ImagemUrl = "eletronicos.jpg", CreatedAt = DateTime.Now },
            new { Id = 3, Nome = "Informática", ImagemUrl = "informatica.jpg", CreatedAt = DateTime.Now },
            new { Id = 4, Nome = "Móveis", ImagemUrl = "moveis.jpg", CreatedAt = DateTime.Now },
            new { Id = 5, Nome = "Eletrodomésticos", ImagemUrl = "eletrodomesticos.jpg", CreatedAt = DateTime.Now },
            new { Id = 6, Nome = "Bebidas", ImagemUrl = "bebidas.jpg", CreatedAt = DateTime.Now },
            new { Id = 7, Nome = "Alimentos", ImagemUrl = "alimentos.jpg", CreatedAt = DateTime.Now },
            new { Id = 8, Nome = "Limpeza", ImagemUrl = "limpeza.jpg", CreatedAt = DateTime.Now },
            new { Id = 9, Nome = "Brinquedos", ImagemUrl = "brinquedos.jpg", CreatedAt = DateTime.Now },
            new { Id = 10, Nome = "Livros", ImagemUrl = "livros.jpg", CreatedAt = DateTime.Now },
            new { Id = 11, Nome = "Papelaria", ImagemUrl = "papelaria.jpg", CreatedAt = DateTime.Now },
            new { Id = 12, Nome = "Ferramentas", ImagemUrl = "ferramentas.jpg", CreatedAt = DateTime.Now },
            new { Id = 13, Nome = "Esportes", ImagemUrl = "esportes.jpg", CreatedAt = DateTime.Now },
            new { Id = 14, Nome = "Moda Masculina", ImagemUrl = "moda-masculina.jpg", CreatedAt = DateTime.Now },
            new { Id = 15, Nome = "Moda Feminina", ImagemUrl = "moda-feminina.jpg", CreatedAt = DateTime.Now },
            new { Id = 16, Nome = "Calçados", ImagemUrl = "calcados.jpg", CreatedAt = DateTime.Now },
            new { Id = 17, Nome = "Acessórios", ImagemUrl = "acessorios.jpg", CreatedAt = DateTime.Now },
            new { Id = 18, Nome = "Jardim", ImagemUrl = "jardim.jpg", CreatedAt = DateTime.Now },
            new { Id = 19, Nome = "Automotivo", ImagemUrl = "automotivo.jpg", CreatedAt = DateTime.Now },
            new { Id = 20, Nome = "Pet Shop", ImagemUrl = "petshop.jpg", CreatedAt = DateTime.Now }
        );
    }
}
