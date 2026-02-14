using M1GLSERVER.DTOs;
using M1GLSERVER.Services;
using Microsoft.AspNetCore.Mvc;

namespace M1GLSERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtudiantsController : ControllerBase
    {
        private readonly IEtudiantService _service;

        public EtudiantsController(IEtudiantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtudiantDto>>> GetAll()
        {
            var etudiants = await _service.GetAllAsync();
            return Ok(etudiants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EtudiantDto>> GetById(int id)
        {
            var etudiant = await _service.GetByIdAsync(id);
            if (etudiant == null)
                return NotFound();

            return Ok(etudiant);
        }

        [HttpPost]
        public async Task<ActionResult<EtudiantDto>> Create([FromBody] CreateEtudiantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEtudiantDto dto)
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
