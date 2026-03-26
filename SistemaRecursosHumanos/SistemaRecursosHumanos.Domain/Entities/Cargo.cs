using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Cargo
    {
        public Guid IdCargo { get; set; }

        public string NombreCargo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Sueldo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; } = null!;

        // Relaciones
        public Guid IdDepartamento { get; set; }
        public Departamento Departamento { get; set; } = null!;

        // Relación inversa
        public ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();

        public Cargo(string nombreCargo, string descripcion, decimal sueldo, Guid idDepartamento, DateTime fechaRegistro, string estado)
        {
            if (string.IsNullOrWhiteSpace(nombreCargo))
            {
                throw new ArgumentException("El nombre del cargo no puede estar vacío.");
            }

            IdCargo = Guid.NewGuid();

            NombreCargo = nombreCargo;
            Descripcion = descripcion;
            Sueldo = sueldo;
            IdDepartamento = idDepartamento;
            FechaRegistro = fechaRegistro;
            Estado = estado;
        }
    }
}