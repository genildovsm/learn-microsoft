namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Interface para implementação do padrão Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        IProdutoRepository ProdutoRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        ICategoriaRepository CategoriaRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();
    }
}
