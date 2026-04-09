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
    public class GestionDepartamentoUseCase : IGestionDepartamentoUseCase
    {
        private readonly Contracts.Persistence.IDepartamento _repository;

        public GestionDepartamentoUseCase(IDepartamento repository)
        {
            _repository = repository;
        }

        public async Task<Resultado<DepartamentoModel>> CrearAsync(DepartamentoModel model, CancellationToken ct = default)
        {
            try
            {
                var entity = model.ToEntity();

                var creado = await _repository.AgregarAsync(entity, ct);

                return Resultado.Ok(creado.ToModel());
            }
            catch (Exception ex)
            {
                return Resultado.Fail<DepartamentoModel>(ex.Message);
            }
        }

        public async Task<Resultado<DepartamentoModel>> ActualizarAsync(
            DepartamentoModel model,
            CancellationToken ct = default)
        {
            var existente = await _repository.ObtenerPorIdAsync(model.IdDepartamento, ct);

            if (existente == null)
                return Resultado.Fail<DepartamentoModel>("Departamento no existe");

            existente.Actualizar(
                model.Descripcion,
                model.FechaRegistro,
                model.Estado
            );

            var actualizado = await _repository.ActualizarAsync(existente, ct);

            return Resultado.Ok(actualizado.ToModel());
        }


        public async Task<Resultado<bool>> EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var existente = await _repository.ObtenerPorIdAsync(id, ct);

            if (existente == null)
                return Resultado.Fail<bool>("Departamento no existe");

            await _repository.EliminarAsync(existente, ct);

            return Resultado.Ok(true);
        }

        public async Task<Resultado<IReadOnlyList<DepartamentoModel>>> ObtenerTodosAsync(CancellationToken ct = default)
        {
            var lista = await _repository.ObtenerTodosAsync(ct);

            return Resultado.Ok(lista.ToModels());
        }

        public async Task<Resultado<DepartamentoModel>> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _repository.ObtenerPorIdAsync(id, ct);

            if (entity == null)
                return Resultado.Fail<DepartamentoModel>("No encontrado");

            return Resultado.Ok(entity.ToModel());
        }
    }
}
