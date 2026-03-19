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
    public interface IGestionNominaUseCase
    {
        Task<Resultado<NominaModel>> CalcularNominaAsync(Guid empleadoId, DateTime periodoInicio, DateTime periodoFin, CancellationToken ct = default);
        Task<Resultado<ReciboModel>> GenerarReciboAsync(NominaModel nominaModel, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<NominaModel>>> ConsultarNominaPorEmpleadoAsync(Guid empleadoId, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<NominaModel>>> ObtenerNominasAsync(CancellationToken ct = default);
        Task<Resultado<NominaModel>> ObtenerNominaPorIdAsync(Guid id, CancellationToken ct = default);
    }
}
