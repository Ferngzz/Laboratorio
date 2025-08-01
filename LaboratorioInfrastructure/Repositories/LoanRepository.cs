using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;

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
        throw new NotImplementedException();
    }

    public async Task<Loan> GetByLoanIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Loan> GetByLoanByBookIdAsync(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public async Task AddLoanAsync(Loan loan)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLoanByIdAsync(Loan loan, Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteLoanByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}