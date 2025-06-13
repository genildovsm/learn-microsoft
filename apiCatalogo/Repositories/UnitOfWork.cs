using apiCatalogo.Context;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public class UnitOfWork(ApiCatalogoDbContext context) : IUnitOfWork
    {
        private readonly IProdutoRepository? _produtoRepository;
        private readonly ICategoriaRepository? _categoriaRepository;

        /// <summary>
        /// 
        /// </summary>
        public ApiCatalogoDbContext _context = context;

        /// <summary>
        /// 
        /// </summary>
        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() 
        {
            _context.Dispose();    
        }
    }
}
