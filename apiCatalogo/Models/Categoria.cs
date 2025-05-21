using System.ComponentModel.DataAnnotations.Schema;

namespace apiCatalogo.Models;

/// <summary>
/// Entidade Categoria
/// </summary>
public class Categoria
{
    /// <summary>
    /// Id da categoria
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
    /// Propriedade de navegação
    /// </summary>
    public ICollection<Produto> Produtos { get; set; } = [];
}
