using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Modelo;

public partial class equipo
{
    [Key]
    [StringLength(20)]
    [Required]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    [Required]
    public string? Ciudad { get; set; }
    [Required]
    [StringLength(4)]
    public string? Conferencia { get; set; }
    [Required]
    [StringLength(9)]
    public string? Division { get; set; }

    [InverseProperty("Nombre_equipoNavigation")]
    public virtual ICollection<jugadore> jugadores { get; set; } = new List<jugadore>();

    [InverseProperty("equipo_localNavigation")]
    public virtual ICollection<partido> partidoequipo_localNavigations { get; set; } = new List<partido>();

    [InverseProperty("equipo_visitanteNavigation")]
    public virtual ICollection<partido> partidoequipo_visitanteNavigations { get; set; } = new List<partido>();
}
