using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class RegistrarHistorialUsuarioUseCase
    {
        private readonly IHistorialUsuarioRepositorio _repo;

        public RegistrarHistorialUsuarioUseCase(IHistorialUsuarioRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int usuarioId, string accion)
        {
            var historial = new HistorialUsuario
            {
                Id = 0,
                UsuarioId = usuarioId,
                Accion = accion,
                FechaAccion = DateTime.Now
            };

            _repo.Agregar(historial);
        }
    }
}
