using SistemaRecursosHumanos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRecursosHumanos.Domain.Interfaces
{
    public interface ICargoRepositorio
    {
        void Agregar(Cargo cargo);
        IEnumerable<Cargo> ObtenerTodos();
    }
}
