using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiCatalogo.Models;

/// <summary>
/// Entidade Produto
/// </summary>
public class Produto
{
    /// <summary>
    /// Id do produto
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do produto
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Descricao do produto
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Valor do produto
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// URL da imagem do produto
    /// </summary>
    public string ImagemUrl { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade em estoque do produto
    /// </summary>
    public int QuantidadeEstoque { get; set; }

    /// <summary>
    /// Data de cadastro do produto
    /// </summary>
    public DateTime DataCadastro { get; set; }

    /// <summary>
    /// Id da categoria do produto
    /// </summary>
    public int CategoriaId { get; set; }

    /// <summary>
    /// Propriedade de navegação
    /// </summary>
    [JsonIgnore]
    [NotMapped]
    public Categoria? Categoria { get; set; }

}
