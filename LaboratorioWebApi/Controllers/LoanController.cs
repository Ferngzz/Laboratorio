using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioApplication.Services;
using LaboratorioDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioDomain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET: api/Loan
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            return Ok(await _loanService.GetAllLoansAsync());
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoanDTO>> GetLoan(Guid id)
        {
            if (!await LoanExists(id))
            {
                return NotFound();
            }

            return Ok(await _loanService.GetByLoanIdAsync(id));
        }
        
        [HttpGet("book-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoanDTO>> GetLoanByBookId(Guid bookId)
        {
            return Ok(await _loanService.GetByLoanByBookIdAsync(bookId));
        }

        // PUT: api/Loan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutLoan(Guid id, LoanDTO loanDto)
        {
            if (!await LoanExists(id))
            {
                return NotFound();
            }

            await _loanService.UpdateLoanByIdAsync(loanDto, id);
            
            return NoContent();
        }

        // POST: api/Loan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<LoanCreateDTO>> PostLoan(LoanDTO loanDto)
        {
            var loan = await _loanService.AddLoanAsync(loanDto);

            return CreatedAtAction("GetLoan", new { id = loan.loanId}, loan);
        }

        // DELETE: api/Loan/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteLoan(Guid id)
        {
            if (!await LoanExists(id))
            {
                return NotFound();
            }

            await _loanService.DeleteLoanByIdAsync(id);

            return NoContent();
        }

        [HttpPost("loan-book/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> LoanBookByIdAsync(Guid bookId)
        {
            var loanCreateDto = await _loanService.LoanBookByIdAsync(bookId);
            return CreatedAtAction("GetLoan" ,new {id = loanCreateDto.loanId}, loanCreateDto);
        }

        // public async Task<(LoanFineDTO, decimal)> ReturnBookAsync(Guid bookId, Guid loanId)
        // {
        //     
        // }

        private async Task<bool> LoanExists(Guid id)
        {
            var loan = await _loanService.GetByLoanIdAsync(id);
            return loan != null;
        }
    }
}
