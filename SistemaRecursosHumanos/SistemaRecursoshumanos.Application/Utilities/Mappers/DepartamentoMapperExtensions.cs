using SistemaRecursoshumanos.Application.DTO;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
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

        //mapper del dto
        // 🔹 Model → DTO
        public static DepartamentoDTO ToDTO(this DepartamentoModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new DepartamentoDTO
            {
                IdDepartamento = model.IdDepartamento,
                Descripcion = model.Descripcion,
                FechaRegistro = model.FechaRegistro,
                Estado = model.Estado
            };
        }

        // 🔹 DTO → Model
        public static DepartamentoModel ToModel(this DepartamentoDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new DepartamentoModel
            {
                IdDepartamento = dto.IdDepartamento,
                Descripcion = dto.Descripcion,
                FechaRegistro = dto.FechaRegistro,
                Estado = dto.Estado
            };
        }

        // 🔹 Listas
        public static IReadOnlyList<DepartamentoDTO> ToDTOs(this IEnumerable<DepartamentoModel> models)
            => models.Select(m => m.ToDTO()).ToList();

        public static IReadOnlyList<DepartamentoModel> ToModels(this IEnumerable<DepartamentoDTO> dtos)
            => dtos.Select(d => d.ToModel()).ToList();
    }
}