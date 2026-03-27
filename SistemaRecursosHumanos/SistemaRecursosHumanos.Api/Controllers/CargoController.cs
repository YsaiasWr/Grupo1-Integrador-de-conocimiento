using Microsoft.AspNetCore.Mvc;
using SistemaRecursoshumanos.Application.Contracts.Services;
using SistemaRecursoshumanos.Application.DTO;

using SistemaRecursoshumanos.Application.Utilities.Mappers;

namespace SistemaRecursoshumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly GestionCargosUseCase _service;

        public CargoController(GestionCargosUseCase service)
        {
            _service = service;
        }

        // 🔹 Crear nuevo cargo
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CargoDTO dto, CancellationToken ct)
        {
            var model = dto.ToModel();
            var resultado = await _service.CrearAsync(model, ct);

            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Datos!.IdCargo }, resultado.Datos!.ToDTO());
        }

        // 🔹 Actualizar cargo
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] CargoDTO dto, CancellationToken ct)
        {
            if (id != dto.IdCargo)
                return BadRequest("El ID del cargo no coincide.");

            var model = dto.ToModel();
            var resultado = await _service.ActualizarAsync(model, ct);

            if (!resultado.EsExitoso)
                return NotFound(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTO());
        }

        // 🔹 Eliminar cargo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id, CancellationToken ct)
        {
            var resultado = await _service.EliminarAsync(id, ct);

            if (!resultado.EsExitoso)
                return NotFound(resultado.ErrorMensaje);

            return NoContent();
        }

        // 🔹 Obtener todos los cargos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos(CancellationToken ct)
        {
            var resultado = await _service.ObtenerTodosAsync(ct);

            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTOs());
        }

        // 🔹 Obtener cargo por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(Guid id, CancellationToken ct)
        {
            var resultado = await _service.ObtenerPorIdAsync(id, ct);

            if (!resultado.EsExitoso)
                return NotFound(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTO());
        }
    }
}