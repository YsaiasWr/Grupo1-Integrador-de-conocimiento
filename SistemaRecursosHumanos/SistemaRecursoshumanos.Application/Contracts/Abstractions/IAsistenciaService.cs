using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SistemaRecursoshumanos.Application.Contracts.Persistence;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;
using SistemaRecursoshumanos.Application.Result;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursoshumanos.Application.Utilities.Mappers;


namespace SistemaRecursoshumanos.Application.Contracts.Services
{
    public interface IAsistenciaService
    {
        Task<Resultado<AsistenciaModel>> RegistrarEntradaAsync(AsistenciaModel model, CancellationToken ct = default);
        Task<Resultado<AsistenciaModel>> RegistrarSalidaAsync(Guid idAsistencia, DateTime horaSalida, CancellationToken ct = default);
        Task<Resultado<IReadOnlyList<AsistenciaModel>>> ObtenerTodosAsync(CancellationToken ct = default);
    }
}
