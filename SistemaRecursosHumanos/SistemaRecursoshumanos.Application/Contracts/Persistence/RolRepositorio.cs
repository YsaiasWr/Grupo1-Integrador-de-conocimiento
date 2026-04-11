using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly List<Rol> _roles = new();

        public void Agregar(Rol rol)
        {
            rol.Id = _roles.Count + 1;
            _roles.Add(rol);
        }

        public IEnumerable<Rol> ObtenerTodos() => _roles;
    }
}
