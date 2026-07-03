using System.ComponentModel.DataAnnotations;

namespace ConferenciasAPI.Models
{
    public class Asistente
    {
        [Key]
        public int asistente_id { get; set; }

        [Required]
        public string nombre { get; set; } = string.Empty;

        [Required]
        public string apellido { get; set; } = string.Empty;

        [Required]
        public string email { get; set; } = string.Empty;

        public string telefono { get; set; } = string.Empty;
        
        public int conferencia_id { get; set; }

        public Conferencia? Conferencia { get; set; }
    }
}