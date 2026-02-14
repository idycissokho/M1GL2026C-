using M1GLSERVER.DTOs;
using M1GLSERVER.Services;
using Microsoft.AspNetCore.Mvc;

namespace M1GLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncadreursController : ControllerBase
    {
        private readonly IEncadreurService _service;

        public EncadreursController(IEncadreurService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EncadreurDto>>> GetAll()
        {
            var encadreurs = await _service.GetAllAsync();
            return Ok(encadreurs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EncadreurDto>> GetById(int id)
        {
            var encadreur = await _service.GetByIdAsync(id);
            if (encadreur == null)
                return NotFound();

            return Ok(encadreur);
        }

        [HttpPost]
        public async Task<ActionResult<EncadreurDto>> Create([FromBody] CreateEncadreurDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEncadreurDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
