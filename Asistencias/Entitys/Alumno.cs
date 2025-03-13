using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("alumnos")]
public class alumno
{
    [Key]
    public int idMatricula { get; set; }
    public string nombre { get; set; }
    public string grado { get; set; }
    public string grupo { get; set; }

    public ICollection<asistencia> Asistencias { get; set; }
}
