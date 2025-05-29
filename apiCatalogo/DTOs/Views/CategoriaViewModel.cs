using apiCatalogo.Models;

namespace apiCatalogo.DTOs.Views;

/// <summary>
/// Modelo de visualização
/// </summary>
public class CategoriaViewModel
{
    /// <summary>
    /// identificador da categoria
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome da categoria
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// URL da imagem da categoria
    /// </summary>
    public string ImagemUrl { get; set; } = string.Empty;

    /// <summary>
    /// Construtor
    /// </summary>
    public CategoriaViewModel(){}

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="categoria">Entidade categoria</param>
    public CategoriaViewModel(Categoria categoria)
    {
        Id = categoria.Id;
        Nome = categoria.Nome;
        ImagemUrl = categoria.ImagemUrl;
    }
    
    /// <summary>
    /// Conversão implícita
    /// </summary>
    /// <param name="categoria"></param>
    public static implicit operator CategoriaViewModel? (Categoria categoria)
    {
        if (categoria is null) return null;

        return new CategoriaViewModel
        {
            Id = categoria.Id,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };
    }

}
