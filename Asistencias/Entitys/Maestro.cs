using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("maestros")]
public class maestro
{
    [Key]
    public int idMatricula { get; set; }

    public string? nombre { get; set; }

    public ICollection<asistencia> Asistencias { get; set; }
}
