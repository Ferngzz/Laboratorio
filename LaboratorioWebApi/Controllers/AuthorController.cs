using LaboratorioApplication.DTOs;
using LaboratorioApplication.Services;
using Microsoft.AspNetCore.Mvc;
using LaboratorioDomain.Models;

namespace LaboratorioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Author
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authorsDto = await _authorService.GetAllAuthorsAsync();
            return Ok(authorsDto);
        }
        
        // GET: api/Author?lastName=
        // By Author Last Name
        [HttpGet("by-lastname")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthorsByLastName([FromQuery] string lastName)
        {
            return Ok(await _authorService.GetAllAuthorsByAuthorLastNameAsync(lastName));
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(Guid id)
        {
            var authorDto = await _authorService.GetByAuthorIdAsync(id);

            if (authorDto == null)
            {
                return NotFound();
            }

            return Ok(authorDto);
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutAuthor(Guid id, AuthorDTO authorDto)
        {
            if (!await AuthorExistsAsync(id))
                return NotFound();
            
            await _authorService.UpdateAuthorByIdAsync(authorDto, id);
            
            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(AuthorDTO), StatusCodes.Status201Created)]
        public async Task<ActionResult<Author>> PostAuthor(AuthorDTO authorDto)
        {
            var author = await _authorService.AddAuthorAsync(authorDto);

            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            if (!await AuthorExistsAsync(id))
                return NotFound();

            await _authorService.DeleteAuthorByIdAsync(id);

            return NoContent();
        }

        private async Task<bool> AuthorExistsAsync(Guid id)
        {
            var author = await _authorService.GetByAuthorIdAsync(id);
            return author != null;
        }
    }
}
