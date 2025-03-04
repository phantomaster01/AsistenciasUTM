using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioRepository
{
    Task<Usuario> ObtenerUsuarioPorId(int idAlumno);
    Task<Usuario> ObtenerUsuarioPorUid(string uidRfid);
    Task<IEnumerable<Usuario>> ObtenerAlumnosPorGradoGrupo(int grado, string grupo);
    Task<Usuario> RegistrarUsuario(Usuario usuario);
    Task<IEnumerable<Usuario>> ObtenerUsuariosPorTipo(string tipo);
    Task<IEnumerable<Usuario>> ObtenerUsuarios();
}

