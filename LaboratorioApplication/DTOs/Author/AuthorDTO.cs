namespace LaboratorioApplication.DTOs.Author;

public class AuthorDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required ICollection<Guid> Books { get; set; }
}