using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IAsistenciaRepositorio
    {
        void Agregar(Asistencia asistencia);
        IEnumerable<Asistencia> ObtenerTodas();
    }
}
