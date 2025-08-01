namespace LaboratorioDomain.Models;

public class Author
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}