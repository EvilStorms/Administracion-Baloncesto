using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Modelo;

[PrimaryKey("temporada", "jugador")]
[Index("jugador", Name = "jugador")]
public partial class estadistica
{
    [Key]
    [StringLength(5)]
    public string temporada { get; set; } = null!;

    [Key]
    public int jugador { get; set; }

    public float? Puntos_por_partido { get; set; }

    public float? Asistencias_por_partido { get; set; }

    public float? Tapones_por_partido { get; set; }

    public float? Rebotes_por_partido { get; set; }

    [ForeignKey("jugador")]
    [InverseProperty("estadisticas")]
    public virtual jugadore jugadorNavigation { get; set; } = null!;
}
