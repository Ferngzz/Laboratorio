using System.ComponentModel.DataAnnotations;

namespace LaboratorioWebApi.Models;

public class Author
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}