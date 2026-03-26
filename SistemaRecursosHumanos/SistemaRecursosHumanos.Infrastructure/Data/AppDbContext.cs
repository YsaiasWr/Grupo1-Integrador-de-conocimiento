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

            // (opcional si tienes más)
            // builder.Entity<Empleados>().OwnsOne(e => e.Telefono);
        }
    }
}