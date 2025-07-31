namespace LaboratorioWebApi.Models;

public class Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Loan> Loans { get; set; }
    public virtual List<Author> Authors { get; set; }
}