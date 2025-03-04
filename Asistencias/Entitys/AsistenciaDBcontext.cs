using Microsoft.EntityFrameworkCore;

namespace Asistencias.Entitys
{
    public class AsistenciaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        public AsistenciaContext(DbContextOptions<AsistenciaContext> options) : base(options) { }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
