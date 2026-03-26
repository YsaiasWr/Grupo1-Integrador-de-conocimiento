using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursoshumanos.Application.Models;
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
    }
}
