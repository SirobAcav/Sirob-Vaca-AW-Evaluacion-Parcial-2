using ConferenciasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenciasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Conferencia> Conferencias { get; set; }

        public DbSet<Asistente> Asistentes { get; set; }
    }
}