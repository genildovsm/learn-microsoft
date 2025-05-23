using System.ComponentModel.DataAnnotations;
using apiCatalogo.Models;

namespace apiCatalogo.DTOs.Inputs;

/// <summary>
/// Modelo de entrada de dados para entidade Categoria
/// </summary>
public class CategoriaInputModel
{
    /// <summary>
    /// Nome da categoria
    /// </summary>
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "{0}: Campo obrigatório")]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// URL da imagem da categoria
    /// </summary>
    [Display(Name = "URL da imagem")]
    [Required(ErrorMessage = "{0}: Campo obrigatório")]
    public string ImagemUrl { get; set; } = string.Empty;

    /// <summary>
    /// Conversão implícita
    /// </summary>
    /// <param name="model">Modelo de entrada para categorias</param>
    public static implicit operator Categoria(CategoriaInputModel model)
    {
        return new Categoria
        {
            Nome = model.Nome,
            ImagemUrl = model.ImagemUrl,
        };
    }
}
