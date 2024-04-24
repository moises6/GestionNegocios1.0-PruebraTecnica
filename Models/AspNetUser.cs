using GestionNegocios_PruebraTecnica.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadenasComerciales_PruebraTecnica.Models
{
    [Table("AspNetUsers", Schema = "dbo")]
    public class AspNetUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        // Otras propiedades pertinentes de la tabla AspNetUsers

        // Listas de navegación hacia otras entidades
        public virtual ICollection<CadenaComercial> CadenasComerciales { get; set; }
        public virtual ICollection<SucursalUsuarios> SucursalUsuarios { get; set; }
    }
}
