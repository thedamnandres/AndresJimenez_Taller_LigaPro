using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndresJimenez_Taller_LigaPro.Models;

namespace AndresJimenez_Taller_LigaPro.Data
{
    public class AndresJimenez_Taller_LigaProContext : DbContext
    {
        public AndresJimenez_Taller_LigaProContext (DbContextOptions<AndresJimenez_Taller_LigaProContext> options)
            : base(options)
        {
        }

        public DbSet<AndresJimenez_Taller_LigaPro.Models.Jugador> Jugadores { get; set; } = default!;
        public DbSet<AndresJimenez_Taller_LigaPro.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<AndresJimenez_Taller_LigaPro.Models.Estadio> Estadio { get; set; } = default!;
    }
}
