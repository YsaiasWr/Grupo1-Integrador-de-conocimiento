using Microsoft.AspNetCore.Mvc;
using SistemaRecursosHumanos.Application.UseCases;
using SistemaRecursosHumanos.Domain.Entities;
using SistemaRecursosHumanos.Domain.Interfaces;

Namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route(“api/[controller]”)]
    public class AsistenciaController : ControllerBase
    {
        private readonly RegistrarAsistenciaUseCase _useCase;
        private readonly IAsistenciaRepositorio _repo;

        public AsistenciaController(RegistrarAsistenciaUseCase useCase, IAsistenciaRepositorio repo)
        {
            _useCase = useCase;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Asistencia asistencia)
        {
            _useCase.Ejecutar(asistencia);
            Return Ok(“Asistencia registrada correctamente.”);
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.ObtenerTodas());
    }
}

