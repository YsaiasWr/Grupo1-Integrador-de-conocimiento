using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class RegistrarPermisoUseCase
    {
        private readonly IPermisoRepositorio _repo;

        public RegistrarPermisoUseCase(IPermisoRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(Permiso permiso)
        {
            if (string.IsNullOrWhiteSpace(permiso.Nombre))
                throw new Exception("El nombre del permiso es obligatorio.");

            _repo.Agregar(permiso);
        }
    }
}
