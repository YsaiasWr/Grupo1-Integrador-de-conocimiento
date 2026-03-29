using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route(“api/[controller]”)]
    public class HistorialUsuarioController : ControllerBase
    {
        private readonly RegistrarHistorialUsuarioUseCase _useCase;
        private readonly IHistorialUsuarioRepositorio _repo;

        public HistorialUsuarioController(RegistrarHistorialUsuarioUseCase useCase, IHistorialUsuarioRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] int usuarioId, [FromBody] string accion)
        {
            _useCase.Ejecutar(usuarioId, accion);
            return Ok(“Historial registrado correctamente.”);
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodos());
    }
}
