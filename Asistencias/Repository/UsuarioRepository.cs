using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AsistenciaContext _context;

    public UsuarioRepository(AsistenciaContext context)
    {
        _context = context;
    }

    public async Task<Usuario> ObtenerUsuarioPorId(int idAlumno)
    {
        return await _context.Usuarios.FindAsync(idAlumno);
    }

    public async Task<Usuario> ObtenerUsuarioPorUid(string uidRfid)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.UidRfid == uidRfid);
    }

    public async Task<IEnumerable<Usuario>> ObtenerAlumnosPorGradoGrupo(int grado, string grupo)
    {
        return await _context.Usuarios
            .Where(u => u.Tipo == "alumno" && u.Grado == grado && u.Grupo == grupo)
            .ToListAsync();
    }

    public async Task<Usuario> RegistrarUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario; // Devolver el usuario registrado
    }
    public async Task<IEnumerable<Usuario>> ObtenerUsuariosPorTipo(string tipo)
    {
        return await _context.Usuarios
            .Where(u => u.Tipo == tipo)
            .ToListAsync(); // Obtiene todos los usuarios con el tipo especificado
    }
    public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
    {
        return await _context.Usuarios.ToListAsync(); // Devuelve todos los usuarios
    }
}
