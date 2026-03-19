using Microsoft.AspNetCore.Mvc;
using SistemaRecursoshumanos.Application.Contracts.UseCases;
using SistemaRecursoshumanos.Application.Models;

namespace SistemaRecursoshumanos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IGestionEmpleadosUseCase _useCase;

        public EmpleadosController(IGestionEmpleadosUseCase useCase)
        {
            _useCase = useCase;
        }

        // 🔹 GET: api/empleados
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _useCase.ObtenerEmpleadoAsync();

            if (!result.EsExitoso)
                return StatusCode(result.Codigo, result.ErrorMensaje);

            return Ok(result.Datos);
        }

        // 🔹 GET: api/empleados/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _useCase.ObtenerEmpleadoPorIdAsync(id);

            if (!result.EsExitoso)
                return StatusCode(result.Codigo, result.ErrorMensaje);

            return Ok(result.Datos);
        }

        // 🔹 POST: api/empleados
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpleadoModel model)
        {
            var result = await _useCase.CrearEmpleadoAsync(model);

            if (!result.EsExitoso)
                return StatusCode(result.Codigo, result.ErrorMensaje);

            return Ok(result.Datos);
        }

        // 🔹 PUT: api/empleados
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmpleadoModel model)
        {
            var result = await _useCase.ActualizarEmpleadoAsync(model);

            if (!result.EsExitoso)
                return StatusCode(result.Codigo, result.ErrorMensaje);

            return Ok(result.Datos);
        }

        // 🔹 DELETE: api/empleados/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _useCase.EliminarEmpleadoAsync(id);

            if (!result.EsExitoso)
                return StatusCode(result.Codigo, result.ErrorMensaje);

            return NoContent();
        }
    }
}