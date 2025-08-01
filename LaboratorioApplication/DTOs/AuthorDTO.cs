namespace LaboratorioApplication.DTOs;

public class AuthorDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public virtual List<BookDTO>? Books { get; set; }
}