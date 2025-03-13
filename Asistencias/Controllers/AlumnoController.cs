using Microsoft.AspNetCore.Mvc;

namespace Asistencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoController(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        [HttpPost("registrar")]
        public ActionResult RegistrarAlumno([FromBody] alumno Alumno)
        {
            _alumnoRepository.RegistrarAlumno(Alumno);
            return Ok(Alumno);
        }
    }
}
