using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Entities
{
    public class Asistencia
    {
        public Guid IdAsistencia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string Estado { get; set; } = null!;

        // Relación
        public Guid IdEmpleado { get; set; }
        public Empleados Empleado { get; set; }

        public Asistencia(DateTime fecha, DateTime horaEntrada, DateTime? horaSalida, string estado, Guid idEmpleado)
        {
            IdAsistencia = Guid.NewGuid();

            Fecha = fecha;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            Estado = estado;

            IdEmpleado = idEmpleado;
        }
    }

}
