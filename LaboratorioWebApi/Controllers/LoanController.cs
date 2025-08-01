using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Controllers
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
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans()
        {
            return Ok(await _loanService.GetAllLoansAsync());
        }

        // GET: api/Loan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDTO>> GetLoan(Guid id)
        {
            if (!await LoanExists(id))
            {
                return NotFound();
            }

            return Ok(await _loanService.GetByLoanIdAsync(id));
        }

        // PUT: api/Loan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<Loan>> PostLoan(LoanDTO loanDto)
        {
            var loan = await _loanService.AddLoanAsync(loanDto);

            return CreatedAtAction("GetLoan", new { id = loan.loanId}, loan);
        }

        // DELETE: api/Loan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(Guid id)
        {
            if (!await LoanExists(id))
            {
                return NotFound();
            }

            await _loanService.DeleteLoanByIdAsync(id);

            return NoContent();
        }

        private async Task<bool> LoanExists(Guid id)
        {
            var loan = await _loanService.GetByLoanIdAsync(id);
            return loan != null;
        }
    }
}
