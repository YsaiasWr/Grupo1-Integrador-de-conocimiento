using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class ReporteRepositorio : IReporteRepositorio
    {
        private readonly List<Reporte> _reportes = new();

        public void Agregar(Reporte reporte)
        {
            Reporte.Id = _reportes.Count + 1;
            _reportes.Add(reporte);
        }

        public IEnumerable<Reporte> ObtenerTodos() => _reportes;
    }
}

