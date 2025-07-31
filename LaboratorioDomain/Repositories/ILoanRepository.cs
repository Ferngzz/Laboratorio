using LaboratorioWebApi.Models;

namespace LaboratorioDomain.Repositories;

public interface ILoanRepository
{
    Task<IEnumerable<Loan>> GetAllLoans();
    Task<Loan> GetByLoanId(Guid id);
    Task<Loan> GetByLoanByBookId(Guid bookId);
    Task AddLoan(Loan loan);
    Task UpdateLoanById(Loan loan, Guid id);
    Task DeleteLoanById(Guid id);
}