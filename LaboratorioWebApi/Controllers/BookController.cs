using LaboratorioApplication.DTOs.Book;
using LaboratorioApplication.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioDomain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Book
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDTO>> GetBook(Guid id)
        {
            if (!await BookExists(id))
            {
                return NotFound();
            }

            return Ok(await _bookService.GetByBookIdAsync(id));
        }
        
        // GET: api/Book/by-author-id/5
        [HttpGet("by-author-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBookByAuthorId(Guid authorId)
        {
            return Ok(await _bookService.GetAllBooksByAuthorIdAsync(authorId));
        }

        [HttpGet("author/{authorId}/books-loan-status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBooksLoanStatusByAuthor(Guid authorId)
        {
            return Ok(await _bookService.GetBooksLoanStatusByAuthorIdAsync(authorId));
        }
        
        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutBook(Guid id, BookDTO bookDto)
        {
            if (!await BookExists(id))
            {
                return NotFound();
            }

            await _bookService.UpdateBookByIdAsync(bookDto, id);

            return NoContent();
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BookDTO>> PostBook(BookDTO bookDto)
        {
            var book = await _bookService.AddBookAsync(bookDto);
            return CreatedAtAction("GetBook", new { id = book.BookId }, bookDto);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            if (!await BookExists(id))
            {
                return NotFound();
            }

            await _bookService.DeleteBookByIdAsync(id);

            return NoContent();
        }

        private async Task<bool> BookExists(Guid id)
        {
            var book = await _bookService.GetByBookIdAsync(id);
            return book != null;
        }
    }
}
