using System.ComponentModel.DataAnnotations;
using apiCatalogo.Models;

namespace apiCatalogo.DTOs.Inputs;

/// <summary>
/// Modelo de entrada de dados para entidade Produto
/// </summary>
public class ProdutoInputModel
{
    /// <summary>
    /// Nome
    /// </summary>
    [Display(Name = "Nome do produto")]
    [StringLength(100, ErrorMessage = "Comprimento máximo para '{0}' é de {1} caracteres")]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Descrição
    /// </summary>
    [Display(Name = "Descrição do produto")]
    [StringLength(255, ErrorMessage = "Comprimento máximo para '{0}' é de {1} caracteres")]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Valor
    /// </summary>
    [Display(Name = "Valor do produto")]
    [Range(0, double.MaxValue, ErrorMessage = "{0} não é válido")]    
    public decimal Valor { get; set; } 

    /// <summary>
    /// URL da imagem 
    /// </summary>
    [Display(Name = "URL da imagem do produto")]
    [StringLength(255, ErrorMessage = "Comprimento máximo para '{0}' é de {1} caracteres")]
    public string ImagemUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// Quantidade em estoque
    /// </summary>
    [Display(Name = "Quantidade em estoque do produto")]
    [Range(0, int.MaxValue, ErrorMessage = "{0} não é válido")]    
    public int QuantidadeEstoque { get; set; } 

    /// <summary>
    /// Data do cadastro
    /// </summary>
    [Display(Name = "Data de cadastro")]
    [DataType(DataType.DateTime, ErrorMessage = "{0} não é uma data válida")]    
    public DateTime DataCadastro { get; set; } 

    /// <summary>
    /// ID da categoria do produto
    /// </summary>
    [Display(Name = "ID da categoria")]
    [Range(0, int.MaxValue, ErrorMessage = "{0} não é válido")]    
    public int CategoriaId { get; set; } 

    /// <summary>
    /// Converter a instância de modelo para entidade
    /// </summary>
    public static implicit operator Produto(ProdutoInputModel model)
    {
        if (model is null) return new Produto { };

        return new Produto
        {
            Nome = model.Nome,
            Descricao = model.Descricao,
            ImagemUrl = model.ImagemUrl,
            QuantidadeEstoque = model.QuantidadeEstoque,
            DataCadastro = model.DataCadastro,
            CategoriaId = model.CategoriaId
        };
    }
}
