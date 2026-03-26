using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class AsistenciaRepositorio : IAsistenciaRepositorio
    {
        private readonly List<Asistencia> _asistencias = new();

    // Heredamos de IRepositorio si ya tienen métodos genéricos
    public interface IAsistenciaRepositorio : Irepositorio<Asistencia>
    {
        // Métodos específicos para asistencia
        //Task<IEnumerable<Asistencia>> GetAsistenciasPorEmpleado(int empleadoId);
    }

        public IEnumerable<Asistencia> ObtenerTodas() => _asistencias;
    }
}

