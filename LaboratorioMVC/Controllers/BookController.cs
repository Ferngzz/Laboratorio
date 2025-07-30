using LaboratorioMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMVC.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index(string searchString)
    {
        var booksMockData = new []
        {
            new { Title = "Book Title 1", Description = "A short description of the book goes here."},
            new { Title = "Book Title 2", Description = "Another book description goes here."},
            new { Title = "Book Title 3", Description = "Yet another book description." }
        };
        
        ViewBag.BooksMockData = booksMockData;
        
        var books = booksMockData.ToList().AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            books = books.Where(book => book.Title.Contains(searchString));
        }

        var viewModel = new BookFilterViewModel
        {
            SearchString = searchString
        };
        
        return View();
    }
}