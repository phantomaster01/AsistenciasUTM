using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AlumnoRepository : IAlumnoRepository
{
    private readonly AsistenciaDbContext _context;

    public AlumnoRepository(AsistenciaDbContext context)
    {
        _context = context;
    }

    public async Task<alumno> ObtenerAlumnoPorId(int idMatricula)
    {
        return await _context.Alumnos.FindAsync(idMatricula); // Cambiar 'Usuarios' por 'Alumnos'
    }


    public async Task<IEnumerable<alumno>> ObtenerAlumnosPorGradoYGrupo(string grado, string grupo)
    {
        return await _context.Alumnos
            .Where(a => a.grado == grado && a.grupo == grupo)
            .ToListAsync(); // Cambiar 'Usuarios' por 'Alumnos'
    }

    public async Task<alumno> RegistrarAlumno(alumno alumno)
    {
        _context.Alumnos.Add(alumno);
        await _context.SaveChangesAsync();
        return alumno; // Devolver el alumno registrado
    }

    public async Task<IEnumerable<alumno>> ObtenerAlumnos()
    {
        return await _context.Alumnos.ToListAsync(); // Devuelve todos los alumnos
    }
}
