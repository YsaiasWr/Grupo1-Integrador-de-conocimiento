using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Exceptions
{
    internal class ExcepcionReglaNegocio : Exception
    {
        public ExcepcionReglaNegocio(string msg) : base(msg)
        {
        }
    }
}
