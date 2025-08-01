namespace LaboratorioDomain.Models;

public class Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Loan> Loans { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
}