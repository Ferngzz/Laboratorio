using LaboratorioDomain.Repositories;
using LaboratorioWebApi.Data;
using LaboratorioWebApi.Models;

namespace LaboratorioWebApi.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly BookshelfContext _context;

    public LoanRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Loan>> GetAllLoans()
    {
        throw new NotImplementedException();
    }

    public Task<Loan> GetByLoanId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Loan> GetByLoanByBookId(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public Task AddLoan(Loan loan)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLoanById(Loan loan, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLoanById(Guid id)
    {
        throw new NotImplementedException();
    }
}