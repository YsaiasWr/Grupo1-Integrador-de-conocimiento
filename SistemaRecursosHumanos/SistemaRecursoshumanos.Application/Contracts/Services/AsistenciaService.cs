
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;

using SistemaRecursoshumanos.Application.Utilities.Mappers;
using SistemaRecursosHumanos.Domain.Entities;


namespace SistemaRecursoshumanos.Application.Contracts.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepositorio _repository;

        public AsistenciaService(IAsistenciaRepositorio repository)
        {
            _repository = repository;
        }

        // 🔹 Registrar entrada
        public async Task<Resultado<AsistenciaModel>> RegistrarEntradaAsync(AsistenciaModel model, CancellationToken ct = default)
        {
            var entity = model.ToEntity();

            var creado = await _repository.AgregarAsync(entity, ct);

            return Resultado.Ok(creado.ToModel());
        }

        // 🔹 Registrar salida
        public async Task<Resultado<AsistenciaModel>> RegistrarSalidaAsync(Guid id, DateTime horaSalida, CancellationToken ct = default)
        {
            var entity = await _repository.ObtenerPorIdAsync(id, ct);

            if (entity == null)
                return Resultado.Fail<AsistenciaModel>("Asistencia no encontrada");

            entity.HoraSalida = horaSalida;

            var actualizado = await _repository.ActualizarAsync(entity, ct);

            return Resultado.Ok(actualizado.ToModel());
        }

        // 🔹 Obtener todas
        public async Task<Resultado<IReadOnlyList<AsistenciaModel>>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var lista = await _repository.ObtenerTodosAsync(ct) ?? new List<Asistencia>();
            return Resultado.Ok(lista.ToModels());
        }
    }
}
