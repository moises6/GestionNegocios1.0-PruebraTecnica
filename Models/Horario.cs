using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionNegocios_PruebraTecnica.Models
{
    [Table("Horario", Schema = "dbo")]
    public class Horario
    {
        [Key]
        public int HorarioId { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public int SucursalId { get; set; }

        // Navegación a la entidad de sucursal
        public virtual Sucursal Sucursal { get; set; }
    }
}
