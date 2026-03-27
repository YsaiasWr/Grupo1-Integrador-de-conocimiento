using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.DTO
{
    public class AsistenciaDTO
    {
        public Guid IdAsistencia { get; set; }
        public Guid IdEmpleado { get; set; }
        public string? NombreEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string Estado { get; set; } = null!;
    }
    // DTO para registrar entrada
    public class CrearAsistenciaDTO
    {
        public Guid IdEmpleado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime HoraEntrada { get; set; } = DateTime.Now;
    }

    // DTO para registrar salida
    public class ActualizarAsistenciaDTO
    {
        public Guid IdAsistencia { get; set; }
        public DateTime HoraSalida { get; set; } = DateTime.Now;
    }

}
