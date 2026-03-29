using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route(“api/[controller]”)]
    public class ReporteController : ControllerBase
    {
        private readonly GenerarReporteUseCase _useCase;
        private readonly IReporteRepositorio _repo;

        public ReporteController(GenerarReporteUseCase useCase, IReporteRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Generar([FromBody] string titulo, [FromBody] string contenido)
        {
            _useCase.Ejecutar(titulo, contenido);
            return Ok(“Reporte generado correctamente.”);
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodos());
    }
}
