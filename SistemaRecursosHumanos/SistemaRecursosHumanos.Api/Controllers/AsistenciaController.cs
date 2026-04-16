using Microsoft.AspNetCore.Mvc;

using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.DTO;
using SistemaRecursoshumanos.Application.Utilities.Mappers;

namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _useCase;

        public AsistenciaController(IAsistenciaService useCase)
        {
            _useCase = useCase;
        }

        // ?? Registrar entrada
        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] CrearAsistenciaDTO dto)
        {
            var model = dto.ToModel();
            var result = await _useCase.RegistrarEntradaAsync(model);

            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return CreatedAtAction(nameof(GetPorId), new { id = result.Datos!.IdAsistencia }, result.Datos.ToDTO());
        }

        // ?? Registrar salida
        [HttpPut("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida(Guid id, [FromBody] ActualizarAsistenciaDTO dto)
        {
            var result = await _useCase.RegistrarSalidaAsync(id, dto.HoraSalida);

            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return Ok(result.Datos!.ToDTO());
        }

        // ?? Obtener todas las asistencias
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var result = await _useCase.ObtenerTodosAsync();

            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return Ok(result.Datos!.Select(x => x.ToDTO()));
        }

        // ?? Obtener asistencia por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(Guid id)
        {
            var result = await _useCase.ObtenerTodosAsync(); // Ojo: puedes agregar método ObtenerPorIdAsync
            var asistencia = result.Datos!.FirstOrDefault(a => a.IdAsistencia == id);

            if (asistencia == null) return NotFound("Asistencia no encontrada");

            return Ok(asistencia.ToDTO());
        }
    }

}
