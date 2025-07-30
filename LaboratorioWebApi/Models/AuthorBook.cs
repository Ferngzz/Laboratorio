namespace LaboratorioWebApi.Models;

public class AuthorBook
{
    public Guid AuthorBookId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }
}