using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMVC.Controllers;

public class AuthorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}