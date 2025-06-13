namespace apiCatalogo.Pagination
{
    /// <summary>
    /// 
    /// </summary>
    public class ProdutosFiltroPreco : QueryStringParameters
    {
        /// <summary>
        /// Preço do produto
        /// </summary>
        public decimal? Preco {  get; set; }

        /// <summary>
        /// Ordenação do preço
        /// </summary>
        public string? PrecoCriterio { get; set; }
    }
}
