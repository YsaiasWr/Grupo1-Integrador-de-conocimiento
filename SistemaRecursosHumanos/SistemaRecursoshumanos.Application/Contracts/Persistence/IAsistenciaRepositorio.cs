using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class AsistenciaRepositorio : IAsistenciaRepositorio
    {
        private readonly List<Asistencia> _asistencias = new();

        public void Agregar(Asistencia asistencia)
        {
            asistencia.Id = _asistencias.Count + 1;
            _asistencias.Add(asistencia);
        }

        public IEnumerable<Asistencia> ObtenerTodas() => _asistencias;
    }
}

