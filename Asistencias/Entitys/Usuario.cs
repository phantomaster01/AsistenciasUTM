using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int Id { get; set; }

    [Required]
    [Column("tipo")]
    public string Tipo { get; set; } // "maestro" o "alumno"

    [Required]
    [Column("matricula")]
    public string Matricula { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; }

    [Column("grado")]
    public int? Grado { get; set; } // Solo alumnos

    [Column("grupo")]
    public string? Grupo { get; set; } // Solo alumnos

    [Required]
    [Column("uid_rfid")]
    public string UidRfid { get; set; }
}
