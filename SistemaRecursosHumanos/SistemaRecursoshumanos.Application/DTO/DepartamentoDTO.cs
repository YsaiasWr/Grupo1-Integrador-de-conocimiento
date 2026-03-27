using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.DTO
{
    public class DepartamentoDTO
    {
        public Guid IdDepartamento { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } = null!;
    }
}
