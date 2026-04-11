using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IRolRepositorio
    {
        void Agregar(Rol rol);
        IEnumerable<Rol> ObtenerTodos();
    }
}
