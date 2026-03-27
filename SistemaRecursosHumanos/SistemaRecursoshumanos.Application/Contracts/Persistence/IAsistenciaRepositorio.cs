using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursoshumanos.Application.Contracts.Persistence
{
    
    public interface IAsistenciaRepositorio : Irepositorio<Asistencia>
    {
        // Métodos específicos para asistencia
        //Task<IEnumerable<Asistencia>> GetAsistenciasPorEmpleado(int empleadoId);
    
    }
}

