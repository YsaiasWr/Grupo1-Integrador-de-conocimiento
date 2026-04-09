using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.DTO
{
    
        public class CargoDTO
        {
            public Guid IdCargo { get; set; }
            public string NombreCargo { get; set; } = null!;
            public string Descripcion { get; set; } = null!;
            public decimal Sueldo { get; set; }
            public DateTime FechaRegistro { get; set; }
            public string Estado { get; set; } = null!;
            public Guid IdDepartamento { get; set; }

            // Opcional: mostrar nombre de departamento
            public string? NombreDepartamento { get; set; }
        }
    
}
