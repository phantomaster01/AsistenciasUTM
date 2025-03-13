using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAlumnoRepository
{
    Task<alumno> ObtenerAlumnoPorId(int iidMatricula);
    Task<IEnumerable<alumno>> ObtenerAlumnosPorGradoYGrupo(string grado, string grupo);
    Task<alumno> RegistrarAlumno(alumno Alumno);
    Task<IEnumerable<alumno>> ObtenerAlumnos();
}
