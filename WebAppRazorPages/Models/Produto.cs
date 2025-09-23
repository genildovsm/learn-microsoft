using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppRazorPages.Models;

public class Produto
{
    [Key]
    public int IdProduto { get; set; }

    [Display(Name ="Nome")]
    [Required(ErrorMessage = "Campo {0} é requerido")]
    [MaxLength(255)]
    [Column(TypeName ="varchar")]
    public string Nome { get; set; } = "";

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "Campo {0} é requerido")]
    [MaxLength(255)]
    [Column(TypeName = "varchar")]
    public string Descricao { get; set; } = "";

    [Display(Name = "Preço")]
    [Required(ErrorMessage = "Campo {0} é requerido")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }

    [Display(Name ="Estoque")]
    [Required(ErrorMessage = "Campo {0} é requerido")]
    public int Estoque { get; set; }
}
