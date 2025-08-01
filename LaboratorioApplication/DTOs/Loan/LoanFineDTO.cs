namespace LaboratorioApplication.DTOs.Loan;

public class LoanFineDTO
{
    public Guid LoanId { get; set; }
    public Guid BookId { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public bool Returned { get; set; }
}
