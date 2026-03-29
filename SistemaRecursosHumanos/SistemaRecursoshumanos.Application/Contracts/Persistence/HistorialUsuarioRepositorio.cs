using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class HistorialUsuarioRepositorio : IHistorialUsuarioRepositorio
    {
        private readonly List<HistorialUsuario> _historial = new();

        public void Agregar(HistorialUsuario historial)
        {
            Historial.Id = _historial.Count + 1;
            _historial.Add(historial);
        }

        public IEnumerable<HistorialUsuario> ObtenerTodos() => _historial;
    }
}
