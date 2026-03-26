using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;

namespace SistemaRecursoshumanos.Application.Models
{
    public class AsistenciaModel
    {
        public Guid IdAsistencia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string Estado { get; set; } = null!;

        // Solo FK
        public Guid IdEmpleado { get; set; }

        // Opcional (para mostrar)
        public string? NombreEmpleado { get; set; }
    }
}
