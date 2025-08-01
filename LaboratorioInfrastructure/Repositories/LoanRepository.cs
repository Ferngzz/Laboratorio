using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioInfrastructure.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly BookshelfContext _context;

    public LoanRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await _context.Loans
            .Include(l => l.Book)
            .ToListAsync();
    }

    public async Task<Loan> GetByLoanIdAsync(Guid id)
    {
        return await  _context.Loans
            .Include(l => l.Book)
            .FirstOrDefaultAsync(l => l.LoanId == id);
    }

    public async Task<Loan> GetByLoanByBookIdAsync(Guid bookId)
    {
        return await _context.Loans
            .Include(l => l.Book)
            .FirstOrDefaultAsync(l => l.BookId == bookId);
    }

    public async Task AddLoanAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLoanByIdAsync(Loan loan, Guid id)
    {
        _context.Loans.Update(loan);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLoanByIdAsync(Guid id)
    {
        var existingLoan = await GetByLoanIdAsync(id);
        if (existingLoan != null)
        {
            _context.Loans.Remove(existingLoan);
        }
        
        await _context.SaveChangesAsync();
    }
}