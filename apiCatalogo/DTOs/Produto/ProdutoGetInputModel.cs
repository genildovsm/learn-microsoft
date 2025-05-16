using System.ComponentModel.DataAnnotations;

namespace apiCatalogo.DTOs.Produto;

public class ProdutoGetInputModel
{
    [Display(Name = "ID do produto")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} não possui um valor válido")]
    public int? Id { get; set; }

    [Display(Name = "Nome do produto")]
    [StringLength(100, ErrorMessage = "Comprimento máximo para '{0}' é de {1} caracteres")]
    public string? Nome { get; set; }

    [Display(Name = "Descrição do produto")]
    [StringLength(255, ErrorMessage = "Comprimento máximo para '{0}' é de {1} caracteres")]
    public string? Descricao { get; set; }

    public ProdutoGetInputModel() { }
}
