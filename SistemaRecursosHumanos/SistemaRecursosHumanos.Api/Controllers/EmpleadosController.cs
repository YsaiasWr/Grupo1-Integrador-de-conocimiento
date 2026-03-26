using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route(“api/[controller]”)]
    public class EmpleadoController : ControllerBase
    {
        private readonly RegistrarEmpleadoUseCase _useCase;
        private readonly IEmpleadoRepositorio _repo;

        public EmpleadoController(RegistrarEmpleadoUseCase useCase, IEmpleadoRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Empleado empleado)
        {
            _useCase.Ejecutar(empleado);
            return Ok(“Empleado registrado correctamente.”);
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodos());
    }
}
