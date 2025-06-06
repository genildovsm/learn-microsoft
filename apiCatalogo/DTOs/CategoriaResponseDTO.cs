namespace apiCatalogo.DTOs
{
    /// <summary>
    /// Construtor da classe
    /// </summary>
    public class CategoriaResponseDTO
    {   
        /// <summary>
        /// Id da categoria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// URL da imagem da categoria
        /// </summary>        
        public string ImagemUrl { get; set; } = string.Empty;

    }
}
