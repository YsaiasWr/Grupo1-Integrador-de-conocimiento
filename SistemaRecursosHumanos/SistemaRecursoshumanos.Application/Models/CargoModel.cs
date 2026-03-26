using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Models
{
    public class CargoModel
    {
        public Guid IdCargo { get; set; }

        public string NombreCargo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Sueldo { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; } = null!;

        // Solo FK
        public Guid IdDepartamento { get; set; }

        // Opcional (para mostrar)
        public string? NombreDepartamento { get; set; }

    }
}
