using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    [Table("Item", Schema = "dbo")]
    public class Item
    {
        public int ItemId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public int SucursalId { get; set; }
        public bool Activo { get; set; }

        // Relaciones de navegación
        public virtual Categoria Categoria { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
