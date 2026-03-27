using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.DTO
{
    
    public class EmpleadoDTO
    {
        public Guid IdEmpleado { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string TipoEmpleado { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public decimal Salario { get; set; }
        public Guid IdDepartamento { get; set; }
        public Guid IdCargo { get; set; }
    }

    public class CrearEmpleadoDTO
    {
        public string NombreCompleto { get; set; } = null!;
        public string TipoEmpleado { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public decimal Salario { get; set; }
        public Guid IdDepartamento { get; set; }
        public Guid IdCargo { get; set; }
    }

    public class ActualizarEmpleadoDTO : CrearEmpleadoDTO
    {
        public Guid IdEmpleado { get; set; }
    }
}

