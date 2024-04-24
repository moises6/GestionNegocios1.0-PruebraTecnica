using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    [Table("Categoria", Schema = "dbo")]
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
