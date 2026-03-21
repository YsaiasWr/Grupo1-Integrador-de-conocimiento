using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly List<Empleado> _empleados = new();

        public void Agregar(Empleado empleado)
        {
            Empleado.Id = _empleados.Count + 1;
            _empleados.Add(empleado);
        }

        public IEnumerable<Empleado> ObtenerTodos() => _empleados;
    }
}
