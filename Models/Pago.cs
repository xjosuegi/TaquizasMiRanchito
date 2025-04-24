using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPrueva1.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }

        [Required]
        public string MetodoPago { get; set; } = "Efectivo";

        // Relación
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; } = null!;
    }
}