namespace apiCatalogo.Pagination
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriasFiltroNome : QueryStringParameters
    {
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string? Nome { get; set; }
    }
}
