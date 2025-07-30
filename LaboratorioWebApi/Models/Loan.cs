namespace LaboratorioWebApi.Models;

public class Loan
{
    public Guid Id { get; set; }
    public DateTime WithdrawalDate { get; set; }
    public DateTime DevolutionDate { get; set; }
    public Boolean Returned { get; set; }
    
}