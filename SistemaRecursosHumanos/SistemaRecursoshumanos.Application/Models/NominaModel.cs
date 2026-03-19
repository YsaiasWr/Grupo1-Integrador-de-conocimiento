using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Models
{
    public class NominaModel
    {
        public Guid? Id { get; set; }
        public Guid EmpleadoId { get; set; }
        public EmpleadoModel? Empleado { get; set; }
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal TotalPagar { get; set; }
        public ReciboModel? Recibo { get; set; }
    }
}
