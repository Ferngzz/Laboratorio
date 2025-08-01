namespace LaboratorioApplication.DTOs;

public class AuthorCreateDTO
{
    public Guid AuthorId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}