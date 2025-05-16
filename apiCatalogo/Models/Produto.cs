using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiCatalogo.Models;

public class Produto
{
    public int Id { get; private set; }
   
    public string Nome { get; private set; } = string.Empty;

    public string Descricao { get; private set; }= string.Empty;

    public decimal Valor { get; private set; }

    public string ImagemUrl { get; private set; } = string.Empty;

    public int QuantidadeEstoque { get; private set; }

    public DateTime DataCadastro { get; private set; }

    public int CategoriaId { get; private set; }

    [JsonIgnore]
    public Categoria? Categoria { get; private set; }

}
