namespace LaboratorioWebApi.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Loan> Loans { get; set; }
}