using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppRazorPages.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [MaxLength(255, ErrorMessage = "{0} possui comprimento máximo de {1} caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name ="Data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "{0} deve conter uma data válida")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Informe {0} com 11 dígitos")]
        public string CPF { get; set; } = string.Empty;

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "{0} deve conter um e-mail válido")]
        public string Email { get; set; } = string.Empty;
    }
}
