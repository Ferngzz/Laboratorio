using LaboratorioApplication.DTOs.Author;
using LaboratorioApplication.DTOs.Loan;

namespace LaboratorioApplication.DTOs.Book;

public class BookCreateDTO
{
    public Guid BookId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public virtual ICollection<LoanDTO>? Loans { get; set; }
    public virtual ICollection<AuthorDTO>? Authors { get; set; }
}