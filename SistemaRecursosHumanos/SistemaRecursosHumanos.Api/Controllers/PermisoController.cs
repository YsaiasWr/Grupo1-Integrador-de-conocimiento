using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly RegistrarPermisoUseCase _useCase;
        private readonly IPermisoRepositorio _repo;

        public PermisoController(RegistrarPermisoUseCase useCase, IPermisoRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Permiso permiso)
        {
            _useCase.Ejecutar(permiso);
            return Ok("Permiso registrado correctamente.");
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodos());
    }
}
