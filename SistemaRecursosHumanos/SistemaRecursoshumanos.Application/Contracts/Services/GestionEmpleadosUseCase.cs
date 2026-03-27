
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using SistemaRecursoshumanos.Application.Utilities.Mappers;
using SistemaRecursosHumanos.Domain.Interfaces;


namespace SistemaRecursoshumanos.Application.Services
{
    public class GestionEmpleadosUseCase : IGestionEmpleadosUseCase
    {
        private readonly Contracts.Persistence.IEmpleadoRepositorio _repo;

        public GestionEmpleadosUseCase(Contracts.Persistence.IEmpleadoRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<Resultado<EmpleadoModel>> CrearEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            try
            {
                var entidad = model.ToEntity();
                var creado = await _repo.AgregarAsync(entidad, ct);
                return Resultado.Ok(creado.ToModel());
            }
            catch (Exception ex)
            {
                return Resultado.Fail<EmpleadoModel>(ex.Message);
            }
        }

        public async Task<Resultado<EmpleadoModel>> ActualizarEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            var existente = await _repo.ObtenerPorIdAsync(model.IdEmpleado, ct);
            if (existente == null)
                return Resultado.Fail<EmpleadoModel>("Cargo no existe");
            var actualizado = await _repo.ActualizarAsync(model.ToEntity(), ct);
            return Resultado.Ok(actualizado.ToModel());
        }

        public async Task<Resultado<bool>> EliminarEmpleadoAsync(Guid id, CancellationToken ct = default)
        {
            var empleado = await _repo.ObtenerPorIdAsync(id, ct);
            if (empleado == null)
                return Resultado.Fail<bool>("Empleado no existe");

            try
            {
                await _repo.EliminarAsync(empleado, ct);
                return Resultado.Ok(true);
            }
            catch (Exception ex)
            {
                return Resultado.Fail<bool>(ex.Message);
            }
        }

        public async Task<Resultado<IReadOnlyList<EmpleadoModel>>> ObtenerEmpleadoAsync(CancellationToken ct = default)
        {
            var lista = await _repo.ObtenerTodosAsync(ct);
            return Resultado.Ok(lista.ToModels());
        }

        public async Task<Resultado<EmpleadoModel>> ObtenerEmpleadoPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var entidad = await _repo.ObtenerPorIdAsync(id, ct);
            if (entidad == null)
                return Resultado.Fail<EmpleadoModel>("No existe");

            return Resultado.Ok(entidad.ToModel());
        }

        public async Task<Resultado<bool>> ExisteEmpleadoAsync(Guid id, CancellationToken ct = default)
        {
            var entidad = await _repo.ObtenerPorIdAsync(id, ct);
            return Resultado.Ok(entidad != null);
        }

        public async Task<Resultado<EmpleadoModel>> GuardarEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            if (model.IdEmpleado == null || model.IdEmpleado == Guid.Empty)
                return await CrearEmpleadoAsync(model, ct);

            return await ActualizarEmpleadoAsync(model, ct);
        }
    }
}

