using M1GLSERVER.DTOs;
using M1GLSERVER.Services;
using Microsoft.AspNetCore.Mvc;

namespace M1GLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilieresController : ControllerBase
    {
        private readonly IFiliereService _service;

        public FilieresController(IFiliereService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FiliereDto>>> GetAll()
        {
            var filieres = await _service.GetAllAsync();
            return Ok(filieres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FiliereDto>> GetById(int id)
        {
            var filiere = await _service.GetByIdAsync(id);
            if (filiere == null)
                return NotFound();

            return Ok(filiere);
        }

        [HttpPost]
        public async Task<ActionResult<FiliereDto>> Create([FromBody] CreateFiliereDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFiliereDto dto)
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
