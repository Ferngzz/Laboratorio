using LaboratorioApplication.DTOs;
using LaboratorioDomain.Models;
using LaboratorioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMVC.Controllers;

public class BookController : Controller
{
    private readonly BookController _bookController;
    public BookController(BookController bookController)
    {
        _bookController = bookController;
    }

    // GET
    [HttpGet]
    public IActionResult Index(string searchString)
    {
        // Mock Authors
        var author1 = new Author { AuthorId = Guid.NewGuid(), FirstName = "Carlos", LastName = "Ruiz Zafón" };
        var author2 = new Author { AuthorId = Guid.NewGuid(), FirstName = "Andy", LastName = "Weir" };
        var author3 = new Author { AuthorId = Guid.NewGuid(), FirstName = "Yuval", LastName = "Harari" };
        var author4 = new Author { AuthorId = Guid.NewGuid(), FirstName = "Madeline", LastName = "Miller" };

        // Mock Books
        var booksMockData = new List<Book>
        {
            new Book
            {
                BookId = Guid.NewGuid(),
                Title = "The Shadow of the Wind",
                Description = "A sprawling saga of mystery...",
                Authors = new List<Author> { author1 },
                Loans = new List<Loan>()
            },
            new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Project Hail Mary",
                Description = "An amnesiac astronaut awakens...",
                Authors = new List<Author> { author2 },
                Loans = new List<Loan>()
            },
            new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Sapiens: A Brief History of Humankind",
                Description = "A sweeping narrative of humanity's history...",
                Authors = new List<Author> { author3 },
                Loans = new List<Loan>()
            },
            new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Circe",
                Description = "A modern retelling of the Greek myth...",
                Authors = new List<Author> { author4 },
                Loans = new List<Loan>()
            },
            new Book
            {
                BookId = Guid.NewGuid(),
                Title = "Circe",
                Description = "A modern retelling of the Greek myth...",
                Authors = new List<Author> { author4 },
                Loans = new List<Loan>()
            }
            // Add more books similarly...
        };

        // Assign books to authors
        author1.Books = booksMockData.Where(b => b.Authors.Contains(author1)).ToList();
        author2.Books = booksMockData.Where(b => b.Authors.Contains(author2)).ToList();
        author3.Books = booksMockData.Where(b => b.Authors.Contains(author3)).ToList();
        author4.Books = booksMockData.Where(b => b.Authors.Contains(author4)).ToList();

        // Mock Loans
        var loan1 = new Loan
        {
            LoanId = Guid.NewGuid(),
            WithdrawalDate = DateTime.Now.AddDays(-10),
            DevolutionDate = DateTime.Now.AddDays(20),
            Returned = false,
            Book = booksMockData[0]
        };

        booksMockData[0].Loans.Add(loan1);
        booksMockData[1].Loans.Add(loan1);
        booksMockData[2].Loans.Add(loan1);
        booksMockData[3].Loans.Add(loan1);
        

        // Filter logic
        IEnumerable<Book> filteredBooks = booksMockData;

        if (!string.IsNullOrEmpty(searchString))
        {
            filteredBooks = filteredBooks.Where(b => b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        var bookFilterViewModel = new BookFilterViewModel
        {
            Books = filteredBooks.ToList(),
            SearchString = searchString
        };

        return View(bookFilterViewModel);
    }

    [HttpPost]
    public IActionResult Index(BookDTO bookDTO)
    {

        
        return RedirectToAction("Index");
    }

}