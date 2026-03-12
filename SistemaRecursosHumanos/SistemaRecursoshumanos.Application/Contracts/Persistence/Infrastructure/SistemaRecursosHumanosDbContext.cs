using Microsoft.EntityFrameworkCore;
using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Infrastructure
{
    public class SistemaRecursosHumanosDbContext : DbContext
    {
        public SistemaRecursosHumanosDbContext(DbContextOptions<SistemaRecursosHumanosDbContext> options)
                : base(options)
        {
        }

        // Aquí registré las entidades
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
