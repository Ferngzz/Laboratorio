namespace LaboratorioApplication.DTOs.Book;

public class BookLoanDTO
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool Returned { get; set; }
    public DateTime DevolutionDate { get; set; }
}