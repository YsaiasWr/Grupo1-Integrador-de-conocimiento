using SistemaRecursoshumanos.Application.DTO;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using System.Security.Cryptography.X509Certificates;
namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class AsistenciaMapperExtensions
    {
        public static AsistenciaModel ToModel(this Asistencia entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new AsistenciaModel
            {
                IdAsistencia = entity.IdAsistencia,
                Fecha = entity.Fecha,
                HoraEntrada = entity.HoraEntrada,
                HoraSalida = entity.HoraSalida,
                Estado = entity.Estado,
                IdEmpleado = entity.IdEmpleado,

                // Opcional (si quieres mostrar nombre)
                NombreEmpleado = entity.Empleado?.NombreCompleto
            };
        }
        public static Asistencia ToEntity(this AsistenciaModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return new Asistencia(
                fecha: model.Fecha,
                horaEntrada: model.HoraEntrada,
                horaSalida: model.HoraSalida,
                estado: model.Estado,
                idEmpleado: model.IdEmpleado
            );
        }
        public static IReadOnlyList<AsistenciaModel> ToModels(this IReadOnlyList<Asistencia> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            return entities.Select(e => e.ToModel()).ToList();
        }

    }
    //mapper del dto
    public static class AsistenciaMapperExtensionsDTO
    {
        // 🔹 CrearAsistenciaDTO → AsistenciaModel
        public static AsistenciaModel ToModel(this CrearAsistenciaDTO dto)
        {
            return new AsistenciaModel
            {
                IdEmpleado = dto.IdEmpleado,
                Fecha = dto.Fecha,
                HoraEntrada = dto.HoraEntrada,
                Estado = "Registrada" // valor por defecto
            };
        }

        // 🔹 ActualizarAsistenciaDTO → AsistenciaModel
        public static AsistenciaModel ToModel(this ActualizarAsistenciaDTO dto)
        {
            return new AsistenciaModel
            {
                IdAsistencia = dto.IdAsistencia,
                HoraSalida = dto.HoraSalida
            };
        }

        // 🔹 AsistenciaModel → AsistenciaDTO (para respuestas)
        public static AsistenciaDTO ToDTO(this AsistenciaModel model)
        {
            return new AsistenciaDTO
            {
                IdAsistencia = model.IdAsistencia,
                IdEmpleado = model.IdEmpleado,
                NombreEmpleado = model.NombreEmpleado,
                Fecha = model.Fecha,
                HoraEntrada = model.HoraEntrada,
                HoraSalida = model.HoraSalida,
                Estado = model.Estado
            };
        }

        // 🔹 Lista de AsistenciaModel → Lista de AsistenciaDTO
        public static IReadOnlyList<AsistenciaDTO> ToDTOs(this IEnumerable<AsistenciaModel> models)
        {
            return models.Select(m => m.ToDTO()).ToList();
        }
    }
}

