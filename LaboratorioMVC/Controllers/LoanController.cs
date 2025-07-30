using Microsoft.AspNetCore.Mvc;

namespace LaboratorioMVC.Controllers;

public class LoanController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}