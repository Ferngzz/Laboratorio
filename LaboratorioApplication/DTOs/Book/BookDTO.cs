using LaboratorioApplication.DTOs.Author;
using LaboratorioApplication.DTOs.Loan;

namespace LaboratorioApplication.DTOs.Book;

public class BookDTO
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public ICollection<LoanDTO>? Loans { get; set; }
    public ICollection<AuthorDTO>? Authors { get; set; }
}