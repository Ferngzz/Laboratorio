using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LaboratorioMVC.Models;

namespace LaboratorioMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var books = new[]
        {
            new { Title = "Book Title 1", Description = "A short description of the book goes here."},
            new { Title = "Book Title 2", Description = "Another book description goes here."},
            new { Title = "Book Title 3", Description = "Yet another book description." }
        };
        
        ViewBag.Books = books;
        
        return View();
    }

    public IActionResult Author()
    {
        return View();
    }
    
    public IActionResult Book()
    {
        return View();
    }
    
    public IActionResult Loan()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
