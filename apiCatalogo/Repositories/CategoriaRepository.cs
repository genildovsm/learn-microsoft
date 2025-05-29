using apiCatalogo.Context;
using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Repositories
{
    #pragma warning disable CS1591 
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApiCatalogoDbContext _context;

        public CategoriaRepository(ApiCatalogoDbContext context)
        {
            _context = context;
        }

        async Task ICategoriaRepository.CategoriaUpdateAsync(Categoria categoria)
        {
            if ( await _context.Categorias.AnyAsync(c => c.Id == categoria.Id) )
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
            }
        }

        async Task<Categoria> ICategoriaRepository.CategoriaCreateAsync(Categoria categoria)
        {
            await _context.AddAsync(categoria);
            await _context.SaveChangesAsync();

            _context.Entry(categoria).State = EntityState.Detached;

            return categoria;
        }
         
        async Task<bool> ICategoriaRepository.CategoriaDeleteAsync(int id)
        { 
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria is not null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return true;
            } 
            
            return false;
        }

        IQueryable<Categoria> ICategoriaRepository.CategoriasProdutosGetAll() 
        {
            return _context.Categorias
                .Include(c => c.Produtos)
                .AsNoTracking();
        }
        
        async Task<Categoria?> ICategoriaRepository.CategoriaGetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }
    }
}
