using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IEmpleadoRepositorio
    {
        void Agregar(Empleado empleado);
        IEnumerable<Empleado> ObtenerTodos();
    }
}
