using System;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Nomina
    {
        public Guid Id { get; private set; }
        public Guid EmpleadoId { get; set; }
        public Empleados Empleado { get; set; } = null!;
        public DateTime PeriodoInicio { get; set; }
        public DateTime PeriodoFin { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal TotalPagar { get; set; }
        public Recibo? Recibo { get; set; }

        public Nomina(Guid empleadoId, DateTime periodoInicio, DateTime periodoFin, decimal totalPagar, DateTime fechaPago, Recibo? recibo = null)
        {
            if (empleadoId == Guid.Empty)
                throw new ArgumentException("EmpleadoId no puede ser vacío", nameof(empleadoId));

            Id = Guid.CreateVersion7();
            EmpleadoId = empleadoId;
            PeriodoInicio = periodoInicio;
            PeriodoFin = periodoFin;
            TotalPagar = totalPagar;
            FechaPago = fechaPago;
            Recibo = recibo;
        }
    }
}
