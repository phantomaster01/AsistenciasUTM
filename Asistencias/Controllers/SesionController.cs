using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asistencias.Controllers
{
    [ApiController]
    [Route("api/sesiones")]
    public class SesionesController : ControllerBase
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionesController(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;
        }

        // Iniciar una nueva sesión
        [HttpPost("iniciar/{idMaestro}")]
        public async Task<IActionResult> IniciarSesion(string idMaestro)
        {
            var sesion = await _sesionRepository.IniciarSesion(idMaestro);

            if (sesion == null)
                return BadRequest(new { mensaje = "Error al iniciar sesión. Verifique los datos del maestro." });

            return Ok(new { mensaje = "Sesión iniciada correctamente", sesion });
        }

        // Finalizar una sesión existente
        [HttpPost("finalizar/{idSesion}")]
        public async Task<IActionResult> FinalizarSesion(int idSesion)
        {
            var sesion = await _sesionRepository.ObtenerSesionPorId(idSesion);

            if (sesion == null)
                return NotFound(new { mensaje = "Sesión no encontrada" });

            await _sesionRepository.FinalizarSesion(idSesion);
            return Ok(new { mensaje = "Sesión finalizada correctamente" });
        }

        // Obtener sesiones por maestro
        [HttpGet("maestro/{idMaestro}")]
        public async Task<IActionResult> ObtenerSesionesPorMaestro(string idMaestro)
        {
            var sesiones = await _sesionRepository.ObtenerSesionesPorMaestro(idMaestro);

            if (sesiones == null)
                return NotFound(new { mensaje = "No se encontraron sesiones para el maestro especificado" });

            return Ok(sesiones);
        }

        // Obtener detalles de una sesión por ID
        [HttpGet("{idSesion}")]
        public async Task<IActionResult> ObtenerSesionPorId(int idSesion)
        {
            var sesion = await _sesionRepository.ObtenerSesionPorId(idSesion);

            if (sesion == null)
                return NotFound(new { mensaje = "Sesión no encontrada" });

            return Ok(sesion);
        }
    }
}

