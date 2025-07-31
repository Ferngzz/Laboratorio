namespace LaboratorioWebApi.Models;

public class BookDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<LoanDTO> Loans { get; set; }
    public virtual List<AuthorDTO> Authors { get; set; }
}