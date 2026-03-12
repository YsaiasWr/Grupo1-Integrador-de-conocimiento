using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaRecursosHumanos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SistemaRecursoshumanos.Application.Contracts.Persistence
{

    // Heredamos de IRepositorio si ya tienen métodos genéricos
    public interface IAsistenciaRepositorio : Irepositorio<Asistencia>
    {
        // Métodos específicos para asistencia
        Task<IEnumerable<Asistencia>> GetAsistenciasPorEmpleado(int empleadoId);
    }

}
