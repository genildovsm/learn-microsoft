using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Context.Mapping;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
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

        b.HasIndex(x => x.Nome, "IX_CATEGORIAS_NOME")
        .HasFilter("[nome] IS NOT NULL");

        b.HasData(
            new {Id=1, Nome="Cosméticos", ImagemUrl="cosmeticos.jpg"},
            new {Id=2, Nome="Eletrônicos", ImagemUrl="eletronicos.jpg"},
            new {Id=3, Nome="Informática", ImagemUrl="informatica.jpg"},
            new {Id=4, Nome="Móveis", ImagemUrl="moveis.jpg"},
            new {Id=5, Nome="Eletrodomésticos", ImagemUrl="eletrodomesticos.jpg"},
            new {Id=6, Nome="Bebidas", ImagemUrl="bebidas.jpg"},
            new {Id=7, Nome="Alimentos", ImagemUrl="alimentos.jpg"},
            new {Id=8, Nome="Limpeza", ImagemUrl="limpeza.jpg"},
            new {Id=9, Nome="Brinquedos", ImagemUrl="brinquedos.jpg"},
            new {Id=10, Nome="Livros", ImagemUrl="livros.jpg"},
            new {Id=11, Nome="Papelaria", ImagemUrl="papelaria.jpg"},
            new {Id=12, Nome="Ferramentas", ImagemUrl="ferramentas.jpg"},
            new {Id=13, Nome="Esportes", ImagemUrl="esportes.jpg"},
            new {Id=14, Nome="Moda Masculina", ImagemUrl="moda-masculina.jpg"},
            new {Id=15, Nome="Moda Feminina", ImagemUrl="moda-feminina.jpg"},
            new {Id=16, Nome="Calçados", ImagemUrl="calcados.jpg"},
            new {Id=17, Nome="Acessórios", ImagemUrl="acessorios.jpg"},
            new {Id=18, Nome="Jardim", ImagemUrl="jardim.jpg"},
            new {Id=19, Nome="Automotivo", ImagemUrl="automotivo.jpg"},
            new {Id=20, Nome="Pet Shop", ImagemUrl="petshop.jpg"}
        );
    }
}
