using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiRetailXYZ.Data.Models;

public partial class RetailXyzContext : DbContext
{
    public RetailXyzContext()
    {
    }

    public RetailXyzContext(DbContextOptions<RetailXyzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Encuestado> Encuestado { get; set; }

    public virtual DbSet<Encuesta> Encuesta { get; set; }

    public virtual DbSet<Preguntas> Pregunta { get; set; }

    public virtual DbSet<Respuestas> Respuesta { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SAMUELHURTADO\\SQLEXPRESS; DataBase=RetailXYZ;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Encuestado>(entity =>
        {
            entity.ToTable("Encuestado");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreApellido).HasMaxLength(50);
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.Encuestado).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.EncuestadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Encuestado");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Sucursal");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Categoria).HasMaxLength(20);
            entity.Property(e => e.Escala).HasMaxLength(20);
        });

        modelBuilder.Entity<Respuestas>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Encuesta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.EncuestaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Respuesta_Encuesta");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Respuesta_Pregunta");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("Sucursal");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Provincia).HasMaxLength(50);
            entity.Property(e => e.Sucursal1)
                .HasMaxLength(50)
                .HasColumnName("Sucursal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
