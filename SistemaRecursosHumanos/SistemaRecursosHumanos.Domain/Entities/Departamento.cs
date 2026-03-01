using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Departamento
    {
        public int iddepartamento { get; set; }
        public string descripcion { get; set; }
        public string fecharegistro { get; set; }

        public string estado { get; set; }
    }
}
