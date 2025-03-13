using Asistencias.Repositories;
using Asistencias.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Asistencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaRepository _asistenciaRepository;

        public AsistenciaController(IAsistenciaRepository asistenciaRepository)
        {
            _asistenciaRepository = asistenciaRepository;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarAsistencia([FromBody] AsistenciaRequest asistenciaRequest)
        {
            if (asistenciaRequest == null || asistenciaRequest.idMatriculaAlumno <= 0 || asistenciaRequest.idMatriculaMaestro <= 0)
            {
                return BadRequest(new { message = "Datos de asistencia inválidos" });
            }

            try
            {
                await _asistenciaRepository.RegistrarAsistencia(
                    asistenciaRequest.idMatriculaAlumno,
                    asistenciaRequest.idMatriculaMaestro
                );

                return Ok(new { message = "Asistencia registrada correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpGet("maestro/{maestroId}")]
        public async Task<ActionResult> ObtenerAsistenciasPorMaestro(int maestroId)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorMaestro(maestroId);
            return Ok(asistencias);
        }

        [HttpGet("alumno/{idMatriculaAlumno}")]
        public async Task<ActionResult> ObtenerAsistenciasPorAlumno(int idMatriculaAlumno)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorAlumno(idMatriculaAlumno);
            return Ok(asistencias);
        }

        [HttpGet("grado/{grado}/grupo/{grupo}")]
        public async Task<ActionResult> ObtenerAsistenciasPorGradoYGrupo(string grado, string grupo)
        {
            var asistencias = await _asistenciaRepository.ObtenerAsistenciasPorGradoYGrupo(grado, grupo);
            return Ok(asistencias);
        }
    }
}
