using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

[Table("Asistencias")]
public class Asistencia
{
    [Key]
    [Column("id_asistencia")]
    public int? Id { get; set; }

    [Required]
    [Column("id_sesion")]
    public int IdSesion { get; set; }

    [Required]
    [Column("id_alumno")]
    public int IdAlumno { get; set; }

    [Required]
    [Column("fecha_registro")]
    public DateTime? FechaRegistro { get; set; } = DateTime.Now;

    // Relaciones
    [ForeignKey("IdSesion")]
    public Sesion? Sesion { get; set; }

    [ForeignKey("IdAlumno")]
    public Usuario? Alumno { get; set; }
}

