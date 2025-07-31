namespace LaboratorioWebApi.Models;

public class AuthorDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual List<BookDTO> Books { get; set; }
}