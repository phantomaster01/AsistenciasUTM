using Asistencias.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asistencias.Repositories
{
    public interface IAsistenciaRepository
    {
        Task RegistrarAsistencia(int IdMatriculaAlumno, int IdMatriculaMaestro);
        Task<List<asistencia>> ObtenerAsistenciasPorMaestro(int idMatriculaMaestro);
        Task<List<asistencia>> ObtenerAsistenciasPorAlumno(int idMatriculaAlumno);
        Task<List<asistencia>> ObtenerAsistenciasPorGradoYGrupo(string grado, string grupo);
    }
}
