using System.ComponentModel.DataAnnotations;

namespace apiCatalogo.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriaDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public CategoriaDTO()
        {
        }

        /// <summary>
        /// Id da categoria
        /// </summary>
        [Display(Name = "Id")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} : Valor fora do intervalo")]
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        [Display(Name = "Nome")]
        [StringLength(100, ErrorMessage = "Comprimento de {0} foi excedido")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// URL da imagem da categoria
        /// </summary>
        [Display(Name = "Imagem URL")]
        [StringLength(255, ErrorMessage = "Comprimento de {0} foi excedido")]
        public string ImagemUrl { get; set; } = string.Empty;

    }
}
