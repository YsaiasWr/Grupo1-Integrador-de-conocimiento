using Microsoft.AspNetCore.Mvc;
using SistemaRecursoshumanos.Application.Contracts.Services;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.DTO;

using SistemaRecursoshumanos.Application.Utilities.Mappers;

namespace SistemaRecursoshumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IGestionDepartamentoUseCase _departamentoService;

        public DepartamentoController(IGestionDepartamentoUseCase departamentoService)
        {
            _departamentoService = departamentoService;
        }

        // 🔹 Obtener todos los departamentos
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var resultado = await _departamentoService.ObtenerTodosAsync(ct);
            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTOs());
        }

        // 🔹 Obtener departamento por Id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var resultado = await _departamentoService.ObtenerPorIdAsync(id, ct);
            if (!resultado.EsExitoso)
                return NotFound(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTO());
        }

        // 🔹 Crear nuevo departamento
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartamentoDTO dto, CancellationToken ct)
        {
            var model = dto.ToModel();
            var resultado = await _departamentoService.CrearAsync(model, ct);

            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return CreatedAtAction(nameof(GetById), new { id = resultado.Datos!.IdDepartamento }, resultado.Datos.ToDTO());
        }

        // 🔹 Actualizar departamento
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DepartamentoDTO dto, CancellationToken ct)
        {
            if (id != dto.IdDepartamento)
                return BadRequest("El ID no coincide.");

            var model = dto.ToModel();
            var resultado = await _departamentoService.ActualizarAsync(model, ct);

            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return Ok(resultado.Datos!.ToDTO());
        }

        // 🔹 Eliminar departamento
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var resultado = await _departamentoService.EliminarAsync(id, ct);
            if (!resultado.EsExitoso)
                return BadRequest(resultado.ErrorMensaje);

            return NoContent();
        }
    }
}
