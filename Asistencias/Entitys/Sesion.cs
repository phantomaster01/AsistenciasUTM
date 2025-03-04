using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

[Table("Sesiones")]
public class Sesion
{
    [Key]
    [Column("id_sesion")]
    public int Id { get; set; }

    [Required]
    [Column("id_maestro")]
    public string IdMaestro { get; set; }

    [Required]
    [Column("fecha_inicio")]
    public DateTime FechaInicio { get; set; } = DateTime.Now;

    [Column("fecha_fin")]
    public DateTime? FechaFin { get; set; }

    [Required]
    [Column("estado")]
    public bool Estado { get; set; } = true;

    // Relación con Usuario
    [ForeignKey("IdMaestro")]
    public Usuario Maestro { get; set; }

    public ICollection<Asistencia> Asistencias { get; set; } // Lista de asistencias en la sesión
}
