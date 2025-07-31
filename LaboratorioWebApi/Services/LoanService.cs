using LaboratorioWebApi.Models;
using LaboratorioWebApi.Repositories;

namespace LaboratorioWebApi.Services;

public class LoanService
{
    private readonly LoanRepository _loanRepository;

    public LoanService(LoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }
    
    public Task<IEnumerable<LoanDTO>> GetAllLoans()
    {
        throw new NotImplementedException();
    }

    public Task<LoanDTO> GetByLoanId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<LoanDTO> GetByLoanByBookId(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public Task AddLoan(LoanDTO loanDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLoanById(LoanDTO loanDto, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLoanById(Guid id)
    {
        throw new NotImplementedException();
    }
}