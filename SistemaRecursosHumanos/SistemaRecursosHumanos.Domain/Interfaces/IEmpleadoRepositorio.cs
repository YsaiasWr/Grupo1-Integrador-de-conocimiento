using SistemaRecursosHumanos.Domain.Entities;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface IEmpleadoRepositorio
    {
        void Agregar(Empleados empleado);
        IEnumerable<Empleados> ObtenerTodos();
    }
}
