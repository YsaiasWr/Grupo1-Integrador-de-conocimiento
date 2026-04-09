using SistemaRecursoshumanos.Application.DTO;

using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;

namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class EmpleadosMapperExtensions
    {
        // ================================
        // 🔹 Entity ↔ Model
        // ================================

        public static EmpleadoModel ToModel(this Empleados entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new EmpleadoModel
            {
                IdEmpleado = entity.IdEmpleado,
                TipoEmpleado = entity.TipoEmpleado,
                Documento = entity.Documento.ToString(),
                NombreCompleto = entity.NombreCompleto,
                Telefono = entity.Telefono.ToString(),
                Correo = entity.Correo,
                Genero = entity.Genero,
                Direccion = entity.Direccion,
                Estado = entity.Estado,
                IdCargo = entity.IdCargo,
                IdDepartamento = entity.IdDepartamento,
                FechaNacimiento = entity.FechaNacimiento,
                FechaIngreso = entity.FechaIngreso,
                Salario = entity.Salario,
                Horario = entity.Horario,
                Horas = entity.Horas,
                Imagen = entity.Imagen,

                NombreDepartamento = entity.Departamento?.Descripcion,
                NombreCargo = entity.Cargo?.NombreCargo
            };
        }

        public static Empleados ToEntity(this EmpleadoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Empleados(
                tipoEmpleado: model.TipoEmpleado,
                documento: new DocumentoVO(model.Documento),
                nombreCompleto: model.NombreCompleto,
                telefono: new TelefonoVO(model.Telefono),
                correo: model.Correo,
                genero: model.Genero,
                direccion: model.Direccion,
                estado: model.Estado,
                idDepartamento: model.IdDepartamento,
                idCargo: model.IdCargo,
                fechaNacimiento: model.FechaNacimiento,
                fechaIngreso: model.FechaIngreso,
                salario: model.Salario,
                horario: model.Horario,
                horas: model.Horas,
                imagen: model.Imagen
            );
        }

        public static IReadOnlyList<EmpleadoModel> ToModels(this IEnumerable<Empleados> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            return entities.Select(e => e.ToModel()).ToList();
        }

        public static IReadOnlyList<Empleados> ToEntities(this IEnumerable<EmpleadoModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));
            return models.Select(m => m.ToEntity()).ToList();
        }

        // ================================
        // 🔹 Model ↔ DTO
        // ================================

        public static EmpleadoDTO ToDTO(this EmpleadoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new EmpleadoDTO
            {
                IdEmpleado = model.IdEmpleado,
                Documento = model.Documento,
                Genero = model.Genero,
                Estado = model.Estado,
                FechaIngreso = model.FechaIngreso,
                FechaNacimiento = model.FechaNacimiento,
                Horario = model.Horario,
                Horas = model.Horas,
                NombreCompleto = model.NombreCompleto,
                TipoEmpleado = model.TipoEmpleado,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Direccion = model.Direccion,
                Salario = model.Salario,
                IdDepartamento = model.IdDepartamento,
                IdCargo = model.IdCargo
            };
        }

        public static EmpleadoModel ToModel(this CrearEmpleadoDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmpleadoModel
            {
                IdEmpleado = dto.IdEmpleado,
                Documento = dto.Documento,
                NombreCompleto = dto.NombreCompleto,
                Genero = dto.Genero,
                Estado = dto.Estado,
                Horario = dto.Horario,
                Horas = dto.Horas,
                Imagen = dto.Imagen,
                TipoEmpleado = dto.TipoEmpleado,
                Correo = dto.Correo,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Salario = dto.Salario,
                IdDepartamento = dto.IdDepartamento,
                IdCargo = dto.IdCargo
            };
        }

        public static EmpleadoModel ToModel(this ActualizarEmpleadoDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmpleadoModel
            {
                IdEmpleado = dto.IdEmpleado,
                Documento = dto.Documento,
                NombreCompleto = dto.NombreCompleto,
                Genero = dto.Genero,
                Estado = dto.Estado,
                Horario = dto.Horario,
                Horas = dto.Horas,
                Imagen= dto.Imagen,
                TipoEmpleado = dto.TipoEmpleado,
                Correo = dto.Correo,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Salario = dto.Salario,
                IdDepartamento = dto.IdDepartamento,
                IdCargo = dto.IdCargo
            };
        }

        public static IReadOnlyList<EmpleadoDTO> ToDTOs(this IEnumerable<EmpleadoModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));
            return models.Select(m => m.ToDTO()).ToList();
        }
    }
}