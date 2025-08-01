using LaboratorioDomain.Models;

namespace LaboratorioDomain.IRepositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllLoansAsync();
    Task<Loan> GetByLoanIdAsync(Guid id);
    Task<Loan> GetByLoanByBookIdAsync(Guid bookId);
    Task AddLoanAsync(Loan loan);
    Task UpdateLoanByIdAsync(Loan loan, Guid id);
    Task DeleteLoanByIdAsync(Guid id);
    Task<Loan> LoanBookByIdAsync(Guid bookId);
    // Task<(Loan, decimal)> ReturnBookAsync(Guid bookId);
}