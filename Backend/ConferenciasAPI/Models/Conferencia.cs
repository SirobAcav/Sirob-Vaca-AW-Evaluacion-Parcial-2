using System.ComponentModel.DataAnnotations;

namespace ConferenciasAPI.Models
{
    public class Conferencia
    {
        [Key]
        public int conferencia_id { get; set; }

        [Required]
        public string nombre { get; set; } = string.Empty;

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public string ubicacion { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;
    }
}