
using Microsoft.EntityFrameworkCore;

namespace WebAppRazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Produto> Produto { get; set; }
        public DbSet<Models.Cliente> Cliente { get; set;}
    }
}
