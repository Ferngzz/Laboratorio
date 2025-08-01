namespace LaboratorioApplication.DTOs;

public class LoanDTO
{
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public Boolean Returned { get; set; }
    public virtual required Guid BookId { get; set; }
}