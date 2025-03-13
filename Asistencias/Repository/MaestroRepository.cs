using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Asistencias.Repositories
{
    public class MaestroRepository : IMaestroRepository
    {
        private readonly AsistenciaDbContext _context;

        public MaestroRepository(AsistenciaDbContext context)
        {
            _context = context;
        }

        public async Task<maestro> ObtenerMaestro(int idMatricula)
        {
            return await _context.Maestros.FindAsync(idMatricula);
        }

        public async Task RegistrarMaestro(maestro Maestro)
        {
            _context.Maestros.Add(Maestro);
            await _context.SaveChangesAsync(); // Usar SaveChangesAsync para operaciones asincrónicas
        }
    }
}
