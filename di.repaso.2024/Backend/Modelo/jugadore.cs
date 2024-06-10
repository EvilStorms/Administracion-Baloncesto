using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Modelo;

[Index("Nombre_equipo", Name = "Nombre_equipo")]
public partial class jugadore
{
    [Key]
    public int codigo { get; set; }

    [StringLength(30)]
    public string? Nombre { get; set; }

    [StringLength(20)]
    public string? Procedencia { get; set; }

    [StringLength(4)]
    public string? Altura { get; set; }

    public int? Peso { get; set; }

    [StringLength(5)]
    public string? Posicion { get; set; }

    [StringLength(20)]
    public string? Nombre_equipo { get; set; }

    [ForeignKey("Nombre_equipo")]
    [InverseProperty("jugadores")]
    public virtual equipo? Nombre_equipoNavigation { get; set; }

    [InverseProperty("jugadorNavigation")]
    public virtual ICollection<estadistica> estadisticas { get; set; } = new List<estadistica>();
}
