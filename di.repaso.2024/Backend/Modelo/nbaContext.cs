using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace di.repaso._2024.Backend.Modelo;

public partial class nbaContext : DbContext
{
    public nbaContext()
    {
    }

    public nbaContext(DbContextOptions<nbaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<equipo> equipos { get; set; }

    public virtual DbSet<estadistica> estadisticas { get; set; }

    public virtual DbSet<jugadore> jugadores { get; set; }

    public virtual DbSet<partido> partidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().
                          UseMySQL("server=localhost;port=3306;user=root;password=mysql;database=nba");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<equipo>(entity =>
        {
            entity.HasKey(e => e.Nombre).HasName("PRIMARY");
        });

        modelBuilder.Entity<estadistica>(entity =>
        {
            entity.HasKey(e => new { e.temporada, e.jugador }).HasName("PRIMARY");

            entity.HasOne(d => d.jugadorNavigation).WithMany(p => p.estadisticas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estadisticas_ibfk_1");
        });

        modelBuilder.Entity<jugadore>(entity =>
        {
            entity.HasKey(e => e.codigo).HasName("PRIMARY");

            entity.HasOne(d => d.Nombre_equipoNavigation).WithMany(p => p.jugadores).HasConstraintName("jugadores_ibfk_1");
        });

        modelBuilder.Entity<partido>(entity =>
        {
            entity.HasKey(e => e.codigo).HasName("PRIMARY");

            entity.HasOne(d => d.equipo_localNavigation).WithMany(p => p.partidoequipo_localNavigations).HasConstraintName("partidos_ibfk_1");

            entity.HasOne(d => d.equipo_visitanteNavigation).WithMany(p => p.partidoequipo_visitanteNavigations).HasConstraintName("partidos_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
