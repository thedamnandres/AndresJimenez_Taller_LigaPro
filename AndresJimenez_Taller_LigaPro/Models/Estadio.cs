using System.ComponentModel.DataAnnotations;

namespace AndresJimenez_Taller_LigaPro.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }

        [MaxLength(50)]
        public string Ciudad { get; set; }
        public int Capacidad { get; set; }
    }
}
