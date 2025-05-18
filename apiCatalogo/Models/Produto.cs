using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apiCatalogo.Models;

/// <summary>
/// Entidade Produto
/// </summary>
public class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public string ImagemUrl { get; set; } = string.Empty;

    public int QuantidadeEstoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Categoria? Categoria { get; set; }

}
