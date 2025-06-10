using apiCatalogo.Context;

namespace apiCatalogo.Repositories
{
#pragma warning disable CS1591
    public class UnitOfWork(ApiCatalogoDbContext context) : IUnitOfWork
    {
        private readonly IProdutoRepository? _produtoRepository;
        private readonly ICategoriaRepository? _categoriaRepository;

        public ApiCatalogoDbContext _context = context;

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose() 
        {
            _context.Dispose();    
        }
    }
}
