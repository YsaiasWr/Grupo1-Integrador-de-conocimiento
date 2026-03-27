using Microsoft.AspNetCore.Mvc;

using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.DTO;
using SistemaRecursoshumanos.Application.Utilities.Mappers;


namespace SistemaRecursosHumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IGestionEmpleadosUseCase _empleadoUseCase;

        public EmpleadosController(IGestionEmpleadosUseCase empleadoUseCase)
        {
            _empleadoUseCase = empleadoUseCase;
        }

        // 🔹 Obtener todos los empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetTodos()
        {
            var result = await _empleadoUseCase.ObtenerEmpleadoAsync();
            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return Ok(result.Datos!.Select(x => x.ToDTO()));
        }

        // 🔹 Obtener empleado por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetPorId(Guid id)
        {
            var result = await _empleadoUseCase.ObtenerEmpleadoPorIdAsync(id);
            if (!result.EsExitoso) return NotFound(result.ErrorMensaje);

            return Ok(result.Datos!.ToDTO());
        }

        // 🔹 Crear empleado
        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> Crear([FromBody] CrearEmpleadoDTO dto)
        {
            var model = dto.ToModel();
            var result = await _empleadoUseCase.CrearEmpleadoAsync(model);

            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return CreatedAtAction(nameof(GetPorId), new { id = result.Datos!.IdEmpleado }, result.Datos.ToDTO());
        }

        // 🔹 Actualizar empleado
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> Actualizar(Guid id, [FromBody] ActualizarEmpleadoDTO dto)
        {
            if (id != dto.IdEmpleado) return BadRequest("El Id no coincide con el DTO.");

            var model = dto.ToModel();
            model.IdEmpleado = id;

            var result = await _empleadoUseCase.ActualizarEmpleadoAsync(model);
            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return Ok(result.Datos!.ToDTO());
        }

        // 🔹 Eliminar empleado
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            var result = await _empleadoUseCase.EliminarEmpleadoAsync(id);
            if (!result.EsExitoso) return NotFound(result.ErrorMensaje);

            return NoContent();
        }

        // 🔹 Existe empleado (opcional, útil para validaciones)
        [HttpGet("existe/{id}")]
        public async Task<ActionResult<bool>> Existe(Guid id)
        {
            var result = await _empleadoUseCase.ExisteEmpleadoAsync(id);
            if (!result.EsExitoso) return BadRequest(result.ErrorMensaje);

            return Ok(result.Datos);
        }
    }
}
