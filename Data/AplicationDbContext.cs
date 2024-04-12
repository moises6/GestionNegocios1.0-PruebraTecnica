using GestionNegocios_PruebraTecnica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionNegocios_PruebraTecnica.Data
{
    public class AplicationDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<ApplicationUser> AplicationUsers { get; set; }

       
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ItemMenu> ItemsMenu { get; set; }

    }

    
    
}
