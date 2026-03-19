using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Models
{
    public class ReciboModel
    {
        public Guid? Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public string Detalles { get; set; } = string.Empty;
    }
}
