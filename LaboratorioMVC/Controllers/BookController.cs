using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMVC.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}