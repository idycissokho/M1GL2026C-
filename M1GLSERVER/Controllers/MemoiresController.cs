using M1GLSERVER.DTOs;
using M1GLSERVER.Services;
using Microsoft.AspNetCore.Mvc;

namespace M1GLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemoiresController : ControllerBase
    {
        private readonly IMemoireService _service;

        public MemoiresController(IMemoireService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemoireDto>>> GetAll()
        {
            var memoires = await _service.GetAllAsync();
            return Ok(memoires);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemoireDto>> GetById(int id)
        {
            var memoire = await _service.GetByIdAsync(id);
            if (memoire == null)
                return NotFound(new { message = $"Mémoire avec l'ID {id} introuvable" });

            return Ok(memoire);
        }

        [HttpPost]
        public async Task<ActionResult<MemoireDto>> Create([FromBody] CreateMemoireDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMemoireDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound(new { message = $"Mémoire avec l'ID {id} introuvable" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = $"Mémoire avec l'ID {id} introuvable" });

            return NoContent();
        }
    }
}
