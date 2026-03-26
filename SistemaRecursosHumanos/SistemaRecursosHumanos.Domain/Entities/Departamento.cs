using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Departamento
    {
        public Guid IdDepartamento { get; private set; }

        public string Descripcion { get; private set; } = null!;
        public DateTime FechaRegistro { get; private set; }
        public string Estado { get; private set; } = null!;

        // Relaciones (solo navegación)
        public ICollection<Empleados> Empleados { get; private set; } = new List<Empleados>();
        public ICollection<Cargo> Cargos { get; private set; } = new List<Cargo>();

        public Departamento(string descripcion, DateTime fechaRegistro, string estado)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción del departamento no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.");

            IdDepartamento = Guid.NewGuid();

            Descripcion = descripcion;
            FechaRegistro = fechaRegistro;
            Estado = estado;
        }
    }
}
