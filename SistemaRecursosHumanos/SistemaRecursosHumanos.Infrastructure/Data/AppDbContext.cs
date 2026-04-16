using Microsoft.EntityFrameworkCore;
using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleados> Empleado { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 🔥 CONFIGURAR VALUE OBJECT
            builder.Entity<Empleados>().OwnsOne(e => e.Documento);
            builder.Entity<Empleados>().OwnsOne(e => e.Telefono);

            // 🔹 CLAVES PRIMARIAS
            builder.Entity<Empleados>().HasKey(e => e.IdEmpleado);
            builder.Entity<Departamento>().HasKey(d => d.IdDepartamento);
            builder.Entity<Cargo>().HasKey(c => c.IdCargo);
            builder.Entity<Asistencia>().HasKey(a => a.IdAsistencia);

            // 🔹 CONFIGURACIÓN DECIMAL (🔥 ESTO ES LO QUE TE FALTA)
            builder.Entity<Cargo>()
                .Property(c => c.Sueldo)
                .HasPrecision(18, 2);

            builder.Entity<Empleados>()
                .Property(e => e.Salario)
                .HasPrecision(18, 2);

            // 🔹 RELACIONES

            // Empleados → Departamento (muchos a uno)
            builder.Entity<Empleados>()
                .HasOne(e => e.Departamento)
                .WithMany(d => d.Empleados)
                .HasForeignKey(e => e.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            // Empleados → Cargo (muchos a uno)
            builder.Entity<Empleados>()
                .HasOne(e => e.Cargo)
                .WithMany(c => c.Empleados)
                .HasForeignKey(e => e.IdCargo)
                .OnDelete(DeleteBehavior.Restrict);

            // Cargo → Departamento (muchos a uno)
            builder.Entity<Cargo>()
                .HasOne(c => c.Departamento)
                .WithMany(d => d.Cargos)
                .HasForeignKey(c => c.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            // Asistencia → Empleados (muchos a uno)
            builder.Entity<Asistencia>()
                .HasOne(a => a.Empleado)
                .WithMany(e => e.Asistencias)
                .HasForeignKey(a => a.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}