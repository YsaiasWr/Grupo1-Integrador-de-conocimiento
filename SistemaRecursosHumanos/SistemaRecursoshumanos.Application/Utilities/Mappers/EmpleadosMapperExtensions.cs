using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursoshumanos.Application.Models;
using System.Security.Cryptography.X509Certificates;

namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class EmpleadosMapperExtensions
    {
        // 🔹 Entity → Model
        public static EmpleadoModel ToModel(this Empleados entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new EmpleadoModel
            {
                IdEmpleado = entity.IdEmpleado,
                TipoEmpleado = entity.TipoEmpleado,
                Documento = entity.Documento.ToString(), // si es VO
                NombreCompleto = entity.NombreCompleto,
                Telefono = entity.Telefono.ToString(),   // si es VO
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

                // Opcional
                NombreDepartamento = entity.Departamento?.Descripcion,
                NombreCargo = entity.Cargo?.NombreCargo
            };
        }

        // 🔹 Model → Entity
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

        // 🔹 Listas
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
    }
}
