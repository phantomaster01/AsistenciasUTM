using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("asistencia")]
public class asistencia
{
    [Key]
    public int idAsistencia { get; set; }

    public int idMatriculaAlumno { get; set; }
    public int idMatriculaMaestro { get; set; }

    public DateTime fecha { get; set; } = DateTime.Now;
    public string? estado { get; set; }

    [ForeignKey("idMatriculaAlumno")]
    public alumno? Alumno { get; set; }

    [ForeignKey("idMatriculaMaestro")]
    public maestro? Maestro { get; set; }
}
