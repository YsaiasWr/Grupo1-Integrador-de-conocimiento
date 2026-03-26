using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.ObjectsValues;
using SistemaRecursoshumanos.Application.Models;
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

    }
}

