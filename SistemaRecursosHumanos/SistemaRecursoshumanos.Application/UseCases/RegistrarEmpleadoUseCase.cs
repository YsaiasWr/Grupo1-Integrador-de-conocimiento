using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class RegistrarEmpleadoUseCase
    {
        private readonly IEmpleadoRepositorio _repo;

        public RegistrarEmpleadoUseCase(IEmpleadoRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(Empleado empleado)
        {
            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                throw new Exception(“El nombre del empleado es obligatorio.”);

            _repo.Agregar(empleado);
        }
    }
}

