using LaboratorioWebApi.Models;

namespace LaboratorioMVC.Models;

public class BookFilterViewModel
{
    public List<Book> Books { get; set; }
    public string? SearchString { get; set; }
}