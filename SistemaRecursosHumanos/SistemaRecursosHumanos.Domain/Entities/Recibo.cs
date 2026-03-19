using System;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Recibo
    {
        public Guid Id { get; private set; }
        public Guid NominaId { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Monto { get; set; }
        public string Detalles { get; set; } = string.Empty;

        public Recibo(decimal monto, string detalles, DateTime? fechaEmision = null)
        {
            if (monto < 0)
                throw new ArgumentException("El monto no puede ser negativo", nameof(monto));

            Id = Guid.CreateVersion7();
            Monto = monto;
            Detalles = detalles ?? string.Empty;
            FechaEmision = fechaEmision ?? DateTime.UtcNow;
        }
    }
}
