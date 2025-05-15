namespace apiCatalogo.Models;

public class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public decimal Valor {get; set; }

    public string? ImagemUrl { get; set; }

    public int QuantidadeEstoque { get; set; }
 
    public DateTime DataCadastro {get; set; }
    
    public int CategoriaId { get; set; }
    
    public Categoria Categoria { get; set; } = new Categoria();
}
