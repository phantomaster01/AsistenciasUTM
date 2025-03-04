using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAsistenciaRepository
{
    Task RegistrarAsistencia(Asistencia asistencia);
    Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorMaestro(int idMaestro);
    Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorAlumno(int idAlumno);
    Task<IEnumerable<Asistencia>> ObtenerAsistenciasPorGradoGrupo(int grado, string grupo);
}
