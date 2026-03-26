using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursoshumanos.Application.Models;
using System.Security.Cryptography.X509Certificates;

namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class DepartamentoMapperExtensions
    {
        // 🔹 Entity → Model
        public static DepartamentoModel ToModel(this Departamento entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new DepartamentoModel
            {
                IdDepartamento = entity.IdDepartamento,
                Descripcion = entity.Descripcion,
                FechaRegistro = entity.FechaRegistro,
                Estado = entity.Estado
            };
        }

        // 🔹 Model → Entity
        public static Departamento ToEntity(this DepartamentoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = new Departamento(
                descripcion: model.Descripcion,
                fechaRegistro: model.FechaRegistro,
                estado: model.Estado
            );

            // 🔥 importante para updates
            //entity.IdDepartamento = model.IdDepartamento;

            return entity;
        }

        // 🔹 Lista Entity → Lista Model
        public static IReadOnlyList<DepartamentoModel> ToModels(this IEnumerable<Departamento> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            return entities.Select(e => e.ToModel()).ToList();
        }

        // 🔹 Lista Model → Lista Entity
        public static IReadOnlyList<Departamento> ToEntities(this IEnumerable<DepartamentoModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            return models.Select(m => m.ToEntity()).ToList();
        }
    }
}