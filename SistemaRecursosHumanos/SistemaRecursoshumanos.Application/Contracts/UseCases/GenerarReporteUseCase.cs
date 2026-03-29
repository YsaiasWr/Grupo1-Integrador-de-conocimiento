using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.Application.UseCases
{
    public class GenerarReporteUseCase
    {
        private readonly IReporteRepositorio _repo;

        public GenerarReporteUseCase(IReporteRepositorio repo)
        {
            _repo = repo;
        }

        public void Ejecutar(string titulo, string contenido)
        {
            var reporte = new Reporte
            {
                Id = 0,
                Titulo = titulo,
                Contenido = contenido,
                FechaGeneracion = DateTime.Now
            };

            _repo.Agregar(reporte);
        }
    }
}
