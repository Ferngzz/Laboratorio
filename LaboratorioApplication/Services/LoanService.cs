using AutoMapper;
using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;

namespace LaboratorioApplication.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public LoanService(ILoanRepository loanRepository,  IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LoanDTO>> GetAllLoansAsync()
    {
        var loans = await _loanRepository.GetAllLoansAsync();
        return _mapper.Map<IEnumerable<LoanDTO>>(loans);
    }

    public async Task<LoanDTO?> GetByLoanIdAsync(Guid id)
    {
        var loan = await _loanRepository.GetByLoanIdAsync(id);
        return _mapper.Map<LoanDTO>(loan);
    }

    public async Task<LoanDTO> GetByLoanByBookIdAsync(Guid bookId)
    {
        var loan = await _loanRepository.GetByLoanByBookIdAsync(bookId);
        return _mapper.Map<LoanDTO>(loan);
    }

    public async Task<LoanCreateDTO> AddLoanAsync(LoanDTO loanDto)
    {
        var loan = _mapper.Map<Loan>(loanDto);
        await _loanRepository.AddLoanAsync(loan);
        return _mapper.Map<LoanCreateDTO>(loan);
    }

    public async Task UpdateLoanByIdAsync(LoanDTO loanDto, Guid id)
    {
        var existingLoan = await _loanRepository.GetByLoanIdAsync(id);
        
        if (existingLoan == null)
        {
            throw new NullReferenceException($"No author with id: {id} was found.");
        }
        
        var loan = _mapper.Map(loanDto, existingLoan);
        await _loanRepository.UpdateLoanByIdAsync(loan, id);
    }

    public async Task DeleteLoanByIdAsync(Guid id)
    {
        await _loanRepository.DeleteLoanByIdAsync(id);
    }

    public async Task<LoanCreateDTO> LoanBookByIdAsync(Guid bookId)
    {
        var loan = await _loanRepository.LoanBookByIdAsync(bookId);
        return _mapper.Map<LoanCreateDTO>(loan);
    }

    // public async Task<(LoanFineDTO, decimal)> ReturnBookAsync(Guid bookId, Guid loanId)
    // {
    //     var (loan, fine) = await _loanRepository.ReturnBookAsync(bookId, loanId);
    //
    //     if (loan == null)
    //         return (null, 0);
    //
    //     var loanDto = _mapper.Map<LoanFineDTO>(loan);
    //
    //     return (loanDto, fine);
    // }
}