using SistemaRecursoshumanos.Application.DTO;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using System.Security.Cryptography.X509Certificates;
namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class CargoMapperExtensions
    {
        // 🔹 Entity → Model
        public static CargoModel ToModel(this Cargo entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new CargoModel
            {
                IdCargo = entity.IdCargo,
                NombreCargo = entity.NombreCargo,
                Descripcion = entity.Descripcion,
                Sueldo = entity.Sueldo,
                FechaRegistro = entity.FechaRegistro,
                Estado = entity.Estado,
                IdDepartamento = entity.IdDepartamento,

                // Opcional (para mostrar)
                NombreDepartamento = entity.Departamento?.Descripcion
            };
        }

        // 🔹 Model → Entity
        public static Cargo ToEntity(this CargoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Cargo(
                nombreCargo: model.NombreCargo,
                descripcion: model.Descripcion,
                sueldo: model.Sueldo,
                idDepartamento: model.IdDepartamento,
                fechaRegistro: model.FechaRegistro,
                estado: model.Estado
            );
        }

        // 🔹 Listas
        public static IReadOnlyList<CargoModel> ToModels(this IEnumerable<Cargo> entities)
            => entities.Select(e => e.ToModel()).ToList();

        public static IReadOnlyList<Cargo> ToEntities(this IEnumerable<CargoModel> models)
            => models.Select(m => m.ToEntity()).ToList();

        //mappeador del dto
        // 🔹 Entity → DTO
        public static CargoDTO ToDTO(this Cargo entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new CargoDTO
            {
                IdCargo = entity.IdCargo,
                NombreCargo = entity.NombreCargo,
                Descripcion = entity.Descripcion,
                Sueldo = entity.Sueldo,
                FechaRegistro = entity.FechaRegistro,
                Estado = entity.Estado,
                IdDepartamento = entity.IdDepartamento,
                NombreDepartamento = entity.Departamento?.Descripcion
            };
        }

        // 🔹 Model → DTO
        public static CargoDTO ToDTO(this CargoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new CargoDTO
            {
                IdCargo = model.IdCargo,
                NombreCargo = model.NombreCargo,
                Descripcion = model.Descripcion,
                Sueldo = model.Sueldo,
                FechaRegistro = model.FechaRegistro,
                Estado = model.Estado,
                IdDepartamento = model.IdDepartamento,
                NombreDepartamento = model.NombreDepartamento
            };
        }

        // 🔹 DTO → Model
        public static CargoModel ToModel(this CargoDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new CargoModel
            {
                IdCargo = dto.IdCargo,
                NombreCargo = dto.NombreCargo,
                Descripcion = dto.Descripcion,
                Sueldo = dto.Sueldo,
                FechaRegistro = dto.FechaRegistro,
                Estado = dto.Estado,
                IdDepartamento = dto.IdDepartamento,
                NombreDepartamento = dto.NombreDepartamento
            };
        }

        // 🔹 Listas
        public static IReadOnlyList<CargoDTO> ToDTOs(this IEnumerable<Cargo> entities)
            => entities.Select(e => e.ToDTO()).ToList();

        public static IReadOnlyList<CargoDTO> ToDTOs(this IEnumerable<CargoModel> models)
            => models.Select(m => m.ToDTO()).ToList();
    }
}
