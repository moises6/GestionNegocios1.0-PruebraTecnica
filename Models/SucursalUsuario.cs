using CadenasComerciales_PruebraTecnica.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    public class SucursalUsuarios
    {
        public int SucursalUsuarioId { get; set; }
        public int SucursalId { get; set; }
        public int UsuarioId { get; set; }

        // Navegación a la entidad de usuario y sucursal
        public virtual AspNetUser Usuario { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
