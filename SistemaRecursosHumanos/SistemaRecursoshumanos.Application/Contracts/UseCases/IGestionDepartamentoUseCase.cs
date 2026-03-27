using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Contracts.UseCases
{

    public interface IGestionDepartamentoUseCase
    {
        Task<Resultado<DepartamentoModel>> CrearAsync(DepartamentoModel model, CancellationToken ct = default);
        Task<Resultado<DepartamentoModel>> ActualizarAsync(DepartamentoModel model, CancellationToken ct = default);
        Task<Resultado<bool>> EliminarAsync(Guid id, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<DepartamentoModel>>> ObtenerTodosAsync(CancellationToken ct = default);
        Task<Resultado<DepartamentoModel>> ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
    }
}
