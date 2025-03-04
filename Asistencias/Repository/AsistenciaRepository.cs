using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AsistenciaRepository : IAsistenciaRepository
{
    private readonly AsistenciaContext _context;

    public AsistenciaRepository(AsistenciaContext context)
    {
        _context = context;
    }

    public async Task RegistrarAsistencia(Asistencia asistencia)
    {
        _context.Asistencias.Add(asistencia);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorMaestro(int idMaestro)
    {
        return await _context.Asistencias
            .Include(a => a.Sesion)
            .ThenInclude(s => s.Maestro)
            .Where(a => a.Sesion.IdMaestro == idMaestro)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorAlumno(int idAlumno)
    {
        return await _context.Asistencias
            .Include(a => a.Alumno)
            .Where(a => a.IdAlumno == idAlumno)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorGradoGrupo(int grado, string grupo)
    {
        return await _context.Asistencias
            .Include(a => a.Alumno)
            .Where(a => a.Alumno.Grado == grado && a.Alumno.Grupo == grupo)
            .ToListAsync();
    }
}
