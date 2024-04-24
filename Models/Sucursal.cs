using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    [Table("Sucursal", Schema = "dbo")]
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int CadenaId { get; set; }

        // Relaciones de navegación
        public virtual CadenaComercial CadenaComercial { get; set; }
    }
}
