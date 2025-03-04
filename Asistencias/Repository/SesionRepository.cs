using Asistencias.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SesionRepository : ISesionRepository
{
    private readonly AsistenciaContext _context;

    public SesionRepository(AsistenciaContext context)
    {
        _context = context;
    }

    public async Task<Sesion> ObtenerSesionPorId(int idSesion)
    {
        return await _context.Sesiones.FindAsync(idSesion);
    }

    public async Task<IEnumerable<Sesion>> ObtenerSesionesPorMaestro(string idMaestro)
    {
        return await _context.Sesiones
            .Where(s => s.IdMaestro == idMaestro)
            .ToListAsync();
    }

    public async Task<Sesion> IniciarSesion(string idMaestro)
    {
        var sesion = new Sesion { IdMaestro = idMaestro, FechaInicio = DateTime.Now, Estado = true };
        await _context.Sesiones.AddAsync(sesion);
        await _context.SaveChangesAsync();
        return sesion;
    }

    public async Task FinalizarSesion(int idSesion)
    {
        var sesion = await _context.Sesiones.FindAsync(idSesion);
        if (sesion != null)
        {
            sesion.FechaFin = DateTime.Now;
            sesion.Estado = false;
            await _context.SaveChangesAsync();
        }
    }
}

