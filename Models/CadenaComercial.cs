using CadenasComerciales_PruebraTecnica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    [Table("CadenaComercial", Schema = "dbo")]
  
    public class CadenaComercial
    {
        [Key]
        public int CadenaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioPropietarioId { get; set; }

        // Navegación a la entidad de usuario
        public virtual AspNetUser UsuarioPropietario { get; set; }
    }

}
