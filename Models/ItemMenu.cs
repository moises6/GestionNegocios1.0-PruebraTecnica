using System.ComponentModel.DataAnnotations;

namespace GestionNegocios_PruebraTecnica.Models
{
    public class ItemMenu
    {
        
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? CategoriaId { get; set; }

        public decimal Precio { get; set; }

        public int? NegocioId { get; set; }

     


        
    }
}
