using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IReporteRepositorio
    {
        void Agregar(Reporte reporte);
        IEnumerable<Reporte> ObtenerTodos();
    }
}
