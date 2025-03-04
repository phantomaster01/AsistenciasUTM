using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asistencias.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Registrar un nuevo usuario
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] Usuario usuario)
        {
            // Validación para asegurarse de que el usuario es proporcionado
            if (usuario == null)
            {
                return BadRequest("Usuario no proporcionado");
            }

            // Validación para tipo de usuario (maestro o alumno)
            if (usuario.Tipo != "maestro" && usuario.Tipo != "alumno")
            {
                return BadRequest("Tipo de usuario inválido. Debe ser 'maestro' o 'alumno'.");
            }

            // Llamada al repositorio para registrar el usuario
            var resultado = await _usuarioRepository.RegistrarUsuario(usuario);

            // Si ocurrió algún error al registrar el usuario
            if (resultado == null)
            {
                return BadRequest("Error al registrar el usuario");
            }

            // Retornar respuesta exitosa con el usuario registrado
            return Ok(new { mensaje = "Usuario registrado correctamente", usuario = resultado });
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _usuarioRepository.ObtenerUsuarios();
            return Ok(usuarios);
        }

        // Obtener un usuario por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }

            return Ok(usuario);
        }

        // Obtener usuarios por tipo (maestro o alumno)
        [HttpGet("tipo/{tipo}")]
        public async Task<IActionResult> ObtenerUsuariosPorTipo(string tipo)
        {
            if (tipo != "maestro" && tipo != "alumno")
            {
                return BadRequest("Tipo debe ser 'maestro' o 'alumno'");
            }

            var usuarios = await _usuarioRepository.ObtenerUsuariosPorTipo(tipo);
            return Ok(usuarios);
        }
    }

}
