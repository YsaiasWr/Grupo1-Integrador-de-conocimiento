using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;

namespace SistemaRecursoshumanos.Application.Models
{
    public class DepartamentoModel
    {
        public Guid IdDepartamento { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; } = null!;

        
    }
}
