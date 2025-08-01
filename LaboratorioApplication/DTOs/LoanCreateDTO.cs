namespace LaboratorioApplication.DTOs;

public class LoanCreateDTO
{
    public Guid loanId { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public Boolean Returned { get; set; }
    public virtual required BookDTO BookDto { get; set; }
}