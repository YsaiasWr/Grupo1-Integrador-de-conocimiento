using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly RegistrarRolUseCase _useCase;
        private readonly IRolRepositorio _repo;

        public RolController(RegistrarRolUseCase useCase, IRolRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Rol rol)
        {
            _useCase.Ejecutar(rol);
            return Ok("Rol registrado correctamente.");
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodos());
    }
}

