using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asistencias.Repositories
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly AsistenciaDbContext _context;

        public AsistenciaRepository(AsistenciaDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsistencia(int IdMatriculaAlumno, int IdMatriculaMaestro)
        {
            var alumno = await _context.Alumnos.FindAsync(IdMatriculaAlumno);
            var maestro = await _context.Maestros.FindAsync(IdMatriculaMaestro);

            if (alumno == null || maestro == null)
            {
                throw new Exception("Alumno o Maestro no encontrado");
            }

            var Asistencia = new asistencia
            {
                idMatriculaAlumno = IdMatriculaAlumno,
                idMatriculaMaestro = IdMatriculaMaestro,
                fecha = DateTime.Now,
                estado = "presente"  
            };

            _context.Asistencias.Add(Asistencia);
            await _context.SaveChangesAsync();
        }


        public async Task<List<asistencia>> ObtenerAsistenciasPorMaestro(int IdMatriculaMaestro)
        {
            return await _context.Asistencias
                .Include(a => a.Alumno)
                .Where(a => a.idMatriculaMaestro == IdMatriculaMaestro)
                .ToListAsync();
        }

        public async Task<List<asistencia>> ObtenerAsistenciasPorAlumno(int IdMatriculaAlumno)
        {
            return await _context.Asistencias
                .Include(a => a.Maestro)
                .Where(a => a.idMatriculaAlumno == IdMatriculaAlumno)
                .ToListAsync();
        }

        public async Task<List<asistencia>> ObtenerAsistenciasPorGradoYGrupo(string grado, string grupo)
        {
            return await _context.Asistencias
                .Include(a => a.Alumno)
                .Include(a => a.Maestro)
                .Where(a => a.Alumno.grado == grado && a.Alumno.grupo == grupo)
                .ToListAsync();
        }
    }
}
