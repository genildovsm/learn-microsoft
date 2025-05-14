using System.ComponentModel.DataAnnotations;

namespace apiCatalogo.Models;

public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [Display(Name ="Nome")]
    [StringLength(80, ErrorMessage = "O campo {0} deve ter no máximo {1} cartacteres")]
    public string? Nome { get; set; }

    [Required]
    [Display(Name ="URL da imagem")]
    [StringLength(300, ErrorMessage = "O campo {0} deve ter no máximo {1} cartacteres")]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto> Produtos{ get; set; } = [];
}
