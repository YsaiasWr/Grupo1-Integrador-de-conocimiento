using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Contracts.UseCases
{
    public interface IGestionEmpleadosUseCase
    {
        Task<Resultado<EmpleadoModel>> GuardarEmpleadoAsync(EmpleadoModel model, CancellationToken ct =default);
        Task<Resultado<EmpleadoModel>> CrearEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default);
        Task<Resultado<EmpleadoModel>> ActualizarEmpleadoAsync(EmpleadoModel model, CancellationToken ct = default);
        Task<Resultado<bool>> EliminarEmpleadoAsync(Guid id, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<EmpleadoModel>>> ObtenerEmpleadoAsync(CancellationToken ct = default);
        Task<Resultado<EmpleadoModel>> ObtenerEmpleadoPorIdAsync(Guid id, CancellationToken ct = default);
        Task<Resultado<bool>> ExisteEmpleadoAsync(Guid id, CancellationToken ct = default);



    }
}
