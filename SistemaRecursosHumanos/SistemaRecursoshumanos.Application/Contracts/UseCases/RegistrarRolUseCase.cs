using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class RegistrarRolUseCase
    {
        private readonly IRolRepositorio _repo;

        public RegistrarRolUseCase(IRolRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Nombre))
                throw new Exception("El nombre del rol es obligatorio.");

            _repo.Agregar(rol);
        }
    }
}
