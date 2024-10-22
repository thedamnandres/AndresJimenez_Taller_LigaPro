using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AndresJimenez_Taller_LigaPro.Models
{
    public class Jugador
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La posición es obligatoria")]
        public string Posicion { get; set; }

        [Range(0, 100, ErrorMessage = "La edad esta fuera de rango")]
        public int Edad { get; set; }

        public Equipo? Equipo { get; set; }

        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }
        

    }
}
