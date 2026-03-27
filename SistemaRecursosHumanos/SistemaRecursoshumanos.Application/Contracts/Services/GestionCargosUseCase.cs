using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursoshumanos.Application.Utilities.Mappers;


namespace SistemaRecursoshumanos.Application.Contracts.Services
{
    public class GestionCargosUseCase : IGestionCargosUseCase
    {
        private readonly Contracts.Persistence.ICargo _repository;

        public GestionCargosUseCase(Contracts.Persistence.ICargo repository)
        {
            _repository = repository;
        }

        public async Task<Resultado<CargoModel>> CrearAsync(CargoModel model, CancellationToken ct = default)
        {
            var entity = model.ToEntity();
            var creado = await _repository.AgregarAsync(entity, ct);
            return Resultado.Ok(creado.ToModel());
        }

        public async Task<Resultado<CargoModel>> ActualizarAsync(CargoModel model, CancellationToken ct = default)
        {
            var existente = await _repository.ObtenerPorIdAsync(model.IdCargo, ct);
            if (existente == null)
                return Resultado.Fail<CargoModel>("Cargo no existe");
            var actualizado = await _repository.ActualizarAsync(model.ToEntity(), ct);
            return Resultado.Ok(actualizado.ToModel());
        }

        public async Task<Resultado<bool>> EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var existente = await _repository.ObtenerPorIdAsync(id, ct);
            if (existente == null)
                return Resultado.Fail<bool>("Cargo no existe");
            await _repository.EliminarAsync(existente, ct);
            return Resultado.Ok(true);
        }

        public async Task<Resultado<IReadOnlyList<CargoModel>>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var lista = await _repository.ObtenerTodosAsync(ct);
            return Resultado.Ok(lista.ToModels());
        }

        public async Task<Resultado<CargoModel>> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _repository.ObtenerPorIdAsync(id, ct);
            if (entity == null)
                return Resultado.Fail<CargoModel>("No encontrado");
            return Resultado.Ok(entity.ToModel());
        }
    }
}
