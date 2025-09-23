using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppRazorPages.Data;
using WebAppRazorPages.Models;

#pragma warning disable 
namespace WebAppRazorPages.Pages.ClientesCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IList<Cliente> Clientes { get; set; }

        public ListarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Cliente.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id) 
        {
            if (id is null) return NotFound();

            var cliente = await _context.Cliente.FindAsync(id);

            if ( cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
