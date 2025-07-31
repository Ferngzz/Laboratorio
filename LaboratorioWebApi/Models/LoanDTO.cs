namespace LaboratorioWebApi.Models;

public class LoanDTO
{
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public Boolean Returned { get; set; }
    public virtual BookDTO BookDto { get; set; }
}