using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IHistorialUsuarioRepositorio
    {
        void Agregar(HistorialUsuario historial);
        IEnumerable<HistorialUsuario> ObtenerTodos();
    }
}
