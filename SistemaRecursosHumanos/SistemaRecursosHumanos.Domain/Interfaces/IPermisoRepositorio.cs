using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IPermisoRepositorio
    {
        void Agregar(Permiso permiso);
        IEnumerable<Permiso> ObtenerTodos();
    }
}
