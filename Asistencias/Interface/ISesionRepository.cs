using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISesionRepository
{
    Task<Sesion> ObtenerSesionPorId(int idSesion);
    Task<IEnumerable<Sesion>> ObtenerSesionesPorMaestro(string idMaestro);
    Task<Sesion> IniciarSesion(string idMaestro);
    Task FinalizarSesion(int idSesion);
}
