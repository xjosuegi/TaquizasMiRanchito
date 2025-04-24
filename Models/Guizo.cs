using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaPrueva1.Models
{
    public class Guizo
    {
        [Key]
        public int GuizoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Relación
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; } = null!;
    }
}