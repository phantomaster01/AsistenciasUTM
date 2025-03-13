using Asistencias.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asistencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMaestroRepository _maestroRepository;

        public MaestroController(IMaestroRepository maestroRepository)
        {
            _maestroRepository = maestroRepository;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegistrarMaestro([FromBody] maestro Maestro)
        {
            await _maestroRepository.RegistrarMaestro(Maestro); // Operación asincrónica
            return Ok(Maestro); // Devolver el objeto maestro registrado
        }

        [HttpGet("{idMatricula}")]
        public async Task<ActionResult<maestro>> ObtenerMaestro(int idMatricula)
        {
            var Maestro = await _maestroRepository.ObtenerMaestro(idMatricula);
            if (Maestro == null)
            {
                return NotFound(); // Si no se encuentra el maestro, retorna un 404
            }
            return Ok(Maestro); // Retorna el maestro encontrado
        }
    }
}
