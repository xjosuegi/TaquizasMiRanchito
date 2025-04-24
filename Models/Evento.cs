using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPrueva1.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string NombreCliente { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaEvento { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan HoraEvento { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [Range(50, 350)]
        public int NumeroPersonas { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioTotal { get; set; }

        // Tipos de servicio (combobox)
        public string TipoServicio { get; set; } = "Taquiza";

        // Relaciones
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Guizo> Guizos { get; set; } = new List<Guizo>();
    }
}