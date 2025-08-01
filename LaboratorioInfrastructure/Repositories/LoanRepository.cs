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

    public async Task<Loan> LoanBookByIdAsync(Guid bookId)
    {
        var book = await _context.Books
            .Include(b => b.Loans)
            .FirstOrDefaultAsync(b => b.BookId == bookId);

        if (book == null || book.Loans.Any(l => !l.Returned))
            return null;

        var loan = new Loan
        {
            LoanId = Guid.NewGuid(),
            BookId = bookId,
            WithdrawalDate = DateTime.UtcNow,
            DevolutionDate = DateTime.UtcNow.AddDays(7),
            Returned = false
        };

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    
    // public async Task<(Loan, decimal)> ReturnBookAsync(Guid bookId)
    // {
    //     const decimal finePricePerDay = 2.50m;
    //     
    //     var loan = await _context.Loans.FindAsync(loanId);
    //
    //     if (loan == null || loan.Returned || loan.BookId != bookId)
    //         return (loan, 0);
    //
    //     loan.Returned = true;
    //
    //     var delay = (DateTime.UtcNow - loan.DevolutionDate).Days;
    //     var fine = delay > 0 ? delay * finePricePerDay : 0;
    //
    //     await _context.SaveChangesAsync();
    //
    //     return (loan, fine);
    // }
}