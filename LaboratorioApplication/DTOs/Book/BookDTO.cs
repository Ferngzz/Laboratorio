namespace LaboratorioApplication.DTOs;

public class BookDTO
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public ICollection<LoanDTO>? Loans { get; set; }
    public ICollection<AuthorDTO>? Authors { get; set; }
}