using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursoshumanos.Application.Contracts.Persistence
{
    public interface Irepositorio<T> where T : class
    {
        //Operaciones de escritura
        Task<T> AgregarAsync(T entidad, CancellationToken ct = default);
        Task<T> ActualizarAsync(T entidad,CancellationToken ct = default);
        Task<T> EliminarAsync(T entidad, CancellationToken ct = default);

        //Operaciones de lectura
        Task<T?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<T>> ObtenerTodosAsync(CancellationToken ct = default);
    }
}
