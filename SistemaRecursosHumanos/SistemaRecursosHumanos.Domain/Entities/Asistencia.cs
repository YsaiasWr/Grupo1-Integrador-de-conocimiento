using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Asistencia
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; } // Nullable porque puede que aún no haya salido

        // Relación con Empleado
        public int EmpleadoId { get; set; }
        public Empleados Empleado { get; set; }
    }

}
