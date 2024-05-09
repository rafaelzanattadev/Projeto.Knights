using Microsoft.AspNetCore.Mvc;
using Projeto.Knights.Repository;

namespace Projeto.Knights.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KnightsController :  ControllerBase
    {
        private readonly KnightRepository _knightRepository;

        public KnightsController(KnightRepository knightRepository)
        {
            _knightRepository = knightRepository;
        }

        // GET: /api/knights
        [HttpGet]
        public IActionResult GetKnights()
        {
            var knights = _knightRepository.GetAllKnights();
            return Ok(knights);
        }

        // GET: /api/knights/heroes
        [HttpGet("heroes")]
        public IActionResult GetHeroKnights()
        {
            var heroKnights = _knightRepository.GetHeroKnights();
            return Ok(heroKnights);
        }

        // GET: /api/knights/{id}
        [HttpGet("{id}")]
        public IActionResult GetKnightById(int id)
        {
            var knight = _knightRepository.GetKnightById(id);
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }

        // POST: /api/knights
        [HttpPost]
        public IActionResult AddKnight([FromBody] Knight knight)
        {
            _knightRepository.AddKnight(knight);
            return CreatedAtAction(nameof(GetKnightById), new { id = knight.Id }, knight);
        }

        // DELETE: /api/knights/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteKnight(int id)
        {
            var knight = _knightRepository.GetKnightById(id);
            if (knight == null)
            {
                return NotFound();
            }
            _knightRepository.DeleteKnight(id);
            return NoContent();
        }

        // PUT: /api/knights/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateKnight(int id, [FromBody] Knight knight)
        {
            if (id != knight.Id)
            {
                return BadRequest();
            }
            _knightRepository.UpdateKnight(knight);
            return NoContent();
        }
    }
}

