using LaboratorioApplication.DTOs;

namespace LaboratorioApplication.IServices;

public interface ILoanService
{
    Task<IEnumerable<LoanDTO>> GetAllLoansAsync();
    Task<LoanDTO> GetByLoanIdAsync(Guid id);
    Task<LoanDTO> GetByLoanByBookIdAsync(Guid bookId);
    Task AddLoanAsync(LoanDTO loanDto);
    Task UpdateLoanByIdAsync(LoanDTO loanDto, Guid id);
    Task DeleteLoanByIdAsync(Guid id);
}