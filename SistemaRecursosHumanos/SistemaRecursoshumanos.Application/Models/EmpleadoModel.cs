using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Models
{
    public class EmpleadoModel
    {

        public Guid IdEmpleado { get; set; }

        public string TipoEmpleado { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Salario { get; set; }

        public string Horario { get; set; } = null!;
        public string Horas { get; set; } = null!;
        public string Imagen { get; set; } = null!;

        // Solo IDs (relaciones)
        public Guid IdDepartamento { get; set; }
        public Guid IdCargo { get; set; }

        // Opcional (para mostrar)
        public string? NombreDepartamento { get; set; }
        public string? NombreCargo { get; set; }
    }
}
