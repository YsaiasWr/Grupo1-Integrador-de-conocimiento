using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Core.Persistence
{
    public class PermisoRepositorio : IPermisoRepositorio
    {
        private readonly List<Permiso> _permisos = new();

        public void Agregar(Permiso permiso)
        {
            permiso.Id = _permisos.Count + 1;
            _permisos.Add(permiso);
        }

        public IEnumerable<Permiso> ObtenerTodos() => _permisos;
    }
}
