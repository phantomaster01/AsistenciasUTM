using System.Threading.Tasks;

public interface IMaestroRepository
{
    Task<maestro> ObtenerMaestro(int idMatricula);
    Task RegistrarMaestro(maestro Maestro);
}
