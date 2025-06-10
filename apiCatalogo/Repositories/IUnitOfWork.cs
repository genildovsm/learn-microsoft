namespace apiCatalogo.Repositories
{
#pragma warning disable CS1591
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }

        void Commit();
    }
}
