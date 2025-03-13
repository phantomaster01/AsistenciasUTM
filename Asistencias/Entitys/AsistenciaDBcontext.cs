using Microsoft.EntityFrameworkCore;

namespace Asistencias.Entitys
{
    public class AsistenciaDbContext : DbContext
    {
        public AsistenciaDbContext(DbContextOptions<AsistenciaDbContext> options) : base(options) { }

        public DbSet<alumno> Alumnos { get; set; }
        public DbSet<maestro> Maestros { get; set; }
        public DbSet<asistencia> Asistencias { get; set; }
    }
}
