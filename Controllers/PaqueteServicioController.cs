// PaqueteServicioController.cs
// Clave compuesta (PaqueteId + ServicioId): rutas con ambos ids.
using Microsoft.AspNetCore.Mvc;
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;

namespace generacionDeInformes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteServicioController : ControllerBase
    {
        private readonly IPaqueteServicioService _service;

        public PaqueteServicioController(IPaqueteServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{paqueteId}/{servicioId}")]
        public async Task<IActionResult> GetById(int paqueteId, int servicioId)
        {
            var result = await _service.GetByIdAsync(paqueteId, servicioId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaqueteServicio entity)
        {
            var result = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { paqueteId = result.PaqueteId, servicioId = result.ServicioId }, result);
        }

        [HttpPut("{paqueteId}/{servicioId}")]
        public async Task<IActionResult> Update(int paqueteId, int servicioId, [FromBody] PaqueteServicio entity)
        {
            if (paqueteId != entity.PaqueteId || servicioId != entity.ServicioId) return BadRequest();
            var updated = await _service.UpdateAsync(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{paqueteId}/{servicioId}")]
        public async Task<IActionResult> Delete(int paqueteId, int servicioId)
        {
            var deleted = await _service.DeleteAsync(paqueteId, servicioId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}