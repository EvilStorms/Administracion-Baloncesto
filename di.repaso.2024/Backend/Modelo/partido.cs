using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Modelo;

[Index("equipo_local", Name = "equipo_local")]
[Index("equipo_visitante", Name = "equipo_visitante")]
public partial class partido
{
    [Key]
    public int codigo { get; set; }

    [StringLength(20)]
    public string? equipo_local { get; set; }

    [StringLength(20)]
    public string? equipo_visitante { get; set; }

    public int? puntos_local { get; set; }

    public int? puntos_visitante { get; set; }

    [StringLength(5)]
    public string? temporada { get; set; }

    [ForeignKey("equipo_local")]
    [InverseProperty("partidoequipo_localNavigations")]
    public virtual equipo? equipo_localNavigation { get; set; }

    [ForeignKey("equipo_visitante")]
    [InverseProperty("partidoequipo_visitanteNavigations")]
    public virtual equipo? equipo_visitanteNavigation { get; set; }
}
