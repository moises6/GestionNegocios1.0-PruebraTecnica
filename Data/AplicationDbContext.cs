using CadenasComerciales_PruebraTecnica.Models;
using GestionNegocios_PruebraTecnica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionNegocios_PruebraTecnica.Data
{
    public class AplicationDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<ApplicationUser> AplicationUsers { get; set; }
        public DbSet<GestionNegocios_PruebraTecnica.Models.Categoria> Categoria { get; set; } = default!;

       




    }





}
