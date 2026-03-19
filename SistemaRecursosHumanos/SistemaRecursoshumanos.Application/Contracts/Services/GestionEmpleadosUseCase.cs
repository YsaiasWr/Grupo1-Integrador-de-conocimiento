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

namespace SistemaRecursoshumanos.Application.Services
{
    public class GestionEmpleadosUseCase : IGestionEmpleadosUseCase
    {
        private readonly IEmpleadoRepositorio _repo;

        public GestionEmpleadosUseCase(IEmpleadoRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<Resultado<EmpleadoModel>> CrearEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            // Usar el mapeador para crear la entidad (el constructor de entidad genera el Idinterno)
            var entidad = model.ToEntity();
            var creado = await _repo.AgregarAsync(entidad, ct);

            // Actualizar el id del modelo con el id generado por la entidad
            model.Idempleado = creado.Idempleado;
            return Resultado<EmpleadoModel>.Exito(model);
        }

        public async Task<Resultado<IReadOnlyList<EmpleadoModel>>> ObtenerEmpleadoAsync(CancellationToken ct = default)
        {
            var lista = await _repo.ObtenerTodosAsync(ct);
            var modelos = lista.ToModels();
            return Resultado<IReadOnlyList<EmpleadoModel>>.Exito(modelos);
        }

        public async Task<Resultado<bool>> EliminarEmpleadoAsync(Guid id, CancellationToken ct = default)
        {
            var empleado = await _repo.ObtenerPorIdAsync(id, ct);

            if (empleado == null)
                return Resultado<bool>.Error("No existe");

            await _repo.EliminarAsync(empleado, ct);

            return Resultado<bool>.Exito(true);
        }

        public async Task<Resultado<EmpleadoModel>> ActualizarEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            if (model.Idempleado == null)
                return Resultado<EmpleadoModel>.Error("Id de empleado no proporcionado");

            var existente = await _repo.ObtenerPorIdAsync(model.Idempleado.Value, ct);
            if (existente == null)
                return Resultado<EmpleadoModel>.Error("Empleado no encontrado");

            // Actualizar propiedades (Idempleado tiene setter privado; no se cambia)
            existente.Tipoempleado = model.Tipoempleado;
            existente.Documento = model.Documento;
            existente.NombreCompleto = model.NombreCompleto;
            existente.Telefono = model.Telefono;
            existente.Correo = model.Correo;
            existente.Genero = model.Genero;
            existente.Direccion = model.Direccion;
            existente.Estado = model.Estado;
            existente.oDepartamento = model.oDepartamento;
            existente.oCargo = model.oCargo;
            existente.FechaNacimiento = model.FechaNacimiento;
            existente.Cargo = model.Cargo;
            existente.FechaIngreso = model.FechaIngreso;
            existente.Salario = model.Salario;
            existente.Horario = model.Horario;
            existente.Horas = model.Horas;
            existente.Imagen = model.Imagen;

            await _repo.ActualizarAsync(existente, ct);

            return Resultado<EmpleadoModel>.Exito(model);
        }

        public async Task<Resultado<EmpleadoModel>> ObtenerEmpleadoPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var entidad = await _repo.ObtenerPorIdAsync(id, ct);
            if (entidad == null)
                return Resultado<EmpleadoModel>.Error("No existe");

            var modelo = entidad.ToModel();
            return Resultado<EmpleadoModel>.Exito(modelo);
        }

        public async Task<Resultado<bool>> ExisteEmpleadoAsync(Guid id, CancellationToken ct = default)
        {
            var entidad = await _repo.ObtenerPorIdAsync(id, ct);
            return Resultado<bool>.Exito(entidad != null);
        }

        public async Task<Resultado<EmpleadoModel>> GuardarEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default)
        {
            // Guardar = crear o actualizar según exista Id
            if (model.Idempleado == null || model.Idempleado == Guid.Empty)
                return await CrearEmpleadoAsync(model, ct);

            return await ActualizarEmpleadoAsync(model, ct);
        }
    }
}