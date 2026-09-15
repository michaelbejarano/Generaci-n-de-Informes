// ItinerarioController.cs
using Microsoft.AspNetCore.Mvc;
using generacionDeInformes.Models;
using generacionDeInformes.Services.Interfaces;

namespace generacionDeInformes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItinerarioController : ControllerBase
    {
        private readonly IItinerarioService _service;

        public ItinerarioController(IItinerarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Itinerario entity)
        {
            var result = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.ItinerarioId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Itinerario entity)
        {
            if (id != entity.ItinerarioId) return BadRequest();
            var updated = await _service.UpdateAsync(entity);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}