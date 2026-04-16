
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using SistemaRecursoshumanos.Application.Utilities.Mappers;

using SistemaRecursosHumanos.Domain.ObjectsValues;


namespace SistemaRecursoshumanos.Application.Services
{
    public class EmpleadosService : IEmpleadosService
    {
        private readonly Contracts.Persistence.IEmpleadoRepositorio _repo;

        public EmpleadosService(Contracts.Persistence.IEmpleadoRepositorio repo)
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
                return Resultado.Fail<EmpleadoModel>("Empleado no existe");
            existente.Actualizar(
                
               model.TipoEmpleado,
                new DocumentoVO(model.Documento),
                model.NombreCompleto,
                new TelefonoVO(model.Telefono),
                model.Correo,
                model.Genero,
                model.Direccion,
                model.Estado,
                model.IdDepartamento,
                model.IdCargo,
                model.FechaNacimiento,
                model.FechaIngreso,
                model.Salario,
                model.Horario,
                model.Horas,
                string.IsNullOrEmpty(model.Imagen)
    ? null
    : Convert.FromBase64String(model.Imagen)


            );
            var actualizado = await _repo.ActualizarAsync(existente, ct);
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

