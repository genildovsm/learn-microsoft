using apiCatalogo.Context;
using apiCatalogo.DTOs.Views;
using apiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace apiCatalogo.Repositories
{
    /// <summary>
    /// Repositório de Categoria
    /// </summary>
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApiCatalogoDbContext _context;

        /// <summary>
        /// Contrutor da classe
        /// </summary>
        /// <param name="context">Instância do contexto</param>
        public CategoriaRepository(ApiCatalogoDbContext context)
        {
            _context = context;
        }

        async Task ICategoriaRepository.AtualizarCategoriaAsync(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            _context.Entry(categoria).State = EntityState.Detached;
        }

        async Task<Categoria> ICategoriaRepository.CriarCategoriaAsync(Categoria categoria)
        {
            await _context.AddAsync(categoria);
            await _context.SaveChangesAsync();

            _context.Entry(categoria).State = EntityState.Detached;

            return categoria;
        }

        async Task ICategoriaRepository.DeleteCategoriaAsync(Categoria categoria)
        { 
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        IQueryable<Categoria> ICategoriaRepository.ObterCategoriasProdutos()
        {
            return _context.Categorias
                .Include(c => c.Produtos)
                .AsNoTracking();
        }

        /// <summary>
        /// Obtém uma categoria correspondente ao Id informado
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        async Task<Categoria?> ICategoriaRepository.ObterCategoriaPorIdAsync(int id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
