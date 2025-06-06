using System.ComponentModel.DataAnnotations;

namespace apiCatalogo.DTOs
{
    /// <summary>
    /// Construtor da classe
    /// </summary>
    public class CategoriaRequestDTO
    {
        /// <summary>
        /// Nome da categoria
        /// </summary>
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Comprimento de {0} foi excedido")]
        [Required(ErrorMessage = "{0} : Requerido")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// URL da imagem da categoria
        /// </summary>
        [Display(Name = "Imagem URL")]
        [StringLength(255, ErrorMessage = "Comprimento de {0} foi excedido")]
        [Required(ErrorMessage = "{0} : Requerido")]
        public string ImagemUrl { get; set; } = string.Empty;
    }
}
