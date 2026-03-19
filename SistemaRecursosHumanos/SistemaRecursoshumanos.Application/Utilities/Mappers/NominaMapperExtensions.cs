using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursoshumanos.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Utilities.Mappers
{
    public static class NominaMapperExtensions
    {
        public static NominaModel ToModel(this Nomina entity)
            => new()
            {
                Id = entity.Id,
                EmpleadoId = entity.EmpleadoId,
                PeriodoInicio = entity.PeriodoInicio,
                PeriodoFin = entity.PeriodoFin,
                FechaPago = entity.FechaPago,
                TotalPagar = entity.TotalPagar,
                Recibo = entity.Recibo is null ? null : new ReciboModel
                {
                    Id = entity.Recibo.Id,
                    FechaEmision = entity.Recibo.FechaEmision,
                    Monto = entity.Recibo.Monto,
                    Detalles = entity.Recibo.Detalles
                }
            };

        public static Nomina ToEntity(this NominaModel model)
        {
            var recibo = model.Recibo == null ? null : new Recibo(model.Recibo.Monto, model.Recibo.Detalles, model.Recibo.FechaEmision);
            var nomina = new Nomina(
                empleadoId: model.EmpleadoId,
                periodoInicio: model.PeriodoInicio,
                periodoFin: model.PeriodoFin,
                totalPagar: model.TotalPagar,
                fechaPago: model.FechaPago,
                recibo: recibo
            );

            return nomina;
        }

        public static IReadOnlyList<NominaModel> ToModels(this IReadOnlyList<Nomina> entities)
            => entities.Select(e => e.ToModel()).ToList();

        public static IReadOnlyList<Nomina> ToEntities(this IReadOnlyList<NominaModel> models)
            => models.Select(m => m.ToEntity()).ToList();
    }
}
