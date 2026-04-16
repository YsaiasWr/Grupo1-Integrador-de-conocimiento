using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Contracts.Services
{
     public interface ICargosService
    {
        Task<Resultado<CargoModel>> CrearAsync(CargoModel model, CancellationToken ct = default);
        Task<Resultado<CargoModel>> ActualizarAsync(CargoModel model, CancellationToken ct = default);
        Task<Resultado<bool>> EliminarAsync(Guid id, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<CargoModel>>> ObtenerTodosAsync(CancellationToken ct = default);
        Task<Resultado<CargoModel>> ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
    }
}
