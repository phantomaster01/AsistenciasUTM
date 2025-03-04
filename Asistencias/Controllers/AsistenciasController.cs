using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asistencias.Controllers
{
    [ApiController]
    [Route("api/asistencias")]
    public class AsistenciasController : ControllerBase
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        private readonly ISesionRepository _sesionRepository;  // Se agrega la dependencia de Sesion
        private readonly IUsuarioRepository _usuarioRepository;  // Se agrega la dependencia de Usuario

        public AsistenciasController(IAsistenciaRepository asistenciaRepository,
                                     ISesionRepository sesionRepository,
                                     IUsuarioRepository usuarioRepository)
        {
            _asistenciaRepository = asistenciaRepository;
            _sesionRepository = sesionRepository;  // Asignación correcta
            _usuarioRepository = usuarioRepository;  // Asignación correcta
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarAsistencia([FromBody] Asistencia asistencia)
        {
            // Verificamos que la sesión y el alumno existan
            var sesion = await _sesionRepository.ObtenerSesionPorId(asistencia.IdSesion);
            var alumno = await _usuarioRepository.ObtenerUsuarioPorId(asistencia.IdAlumno);

            if (sesion == null || alumno == null)
                return BadRequest("Sesión o alumno no encontrados");

            // Registramos la asistencia
            await _asistenciaRepository.RegistrarAsistencia(asistencia);
            return Ok(new { mensaje = "Asistencia registrada" });
        }

        [HttpGet("maestro/{idMaestro}")]
        public async Task<IActionResult> ObtenerAsistenciasPorMaestro(int idMaestro)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorMaestro(idMaestro);
            return Ok(asistencias);
        }

        [HttpGet("alumno/{idAlumno}")]
        public async Task<IActionResult> ObtenerAsistenciasPorAlumno(int idAlumno)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorAlumno(idAlumno);
            return Ok(asistencias);
        }

        [HttpGet("grado/{grado}/grupo/{grupo}")]
        public async Task<IActionResult> ObtenerAsistenciasPorGradoGrupo(int grado, string grupo)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorGradoGrupo(grado, grupo);
            return Ok(asistencias);
        }
    }
}
