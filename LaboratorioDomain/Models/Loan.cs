namespace LaboratorioDomain.Models;

public class Loan
{
    public Guid LoanId { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public Boolean Returned { get; set; }

    public virtual Book Book { get; set; }
    public Guid BookId { get; set; }
}