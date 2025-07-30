using LaboratorioMVC.Models;
using LaboratorioWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioMVC.Controllers;

public class BookController : Controller
{
    // GET
    public IActionResult Index(string searchString)
    {
        List<Book> booksMockData = new List<Book>
        {
            new Book { Title = "The Shadow of the Wind", Description = "A sprawling saga of mystery, love, and obsession set in post-war Barcelona, where a young boy discovers a forgotten book that changes his life." },
            new Book { Title = "Project Hail Mary", Description = "An amnesiac astronaut awakens on a solo mission in deep space, tasked with saving humanity from an extinction-level event." },
            new Book { Title = "Sapiens: A Brief History of Humankind", Description = "A sweeping narrative of humanity's history, from the Stone Age to the political and technological revolutions of the modern era." },
            new Book { Title = "Circe", Description = "A modern retelling of the Greek myth of Circe, the powerful witch from The Odyssey, as she finds her place among gods and mortals." },
            new Book { Title = "The Silent Patient", Description = "A psychotherapist becomes dangerously obsessed with a famous painter who has gone silent after murdering her husband." },
            new Book { Title = "Dune", Description = "In the distant future, a noble house battles for control of a desert planet that holds the only source of a life-extending substance." },
            new Book { Title = "Atomic Habits", Description = "A practical guide on how to build good habits and break bad ones through small, incremental daily improvements." },
            new Book { Title = "Where the Crawdads Sing", Description = "A beautiful and haunting coming-of-age story of a young girl who survives alone in the marshes of North Carolina, intertwined with a murder mystery." },
            new Book { Title = "The Midnight Library", Description = "Between life and death, a library offers the chance to try out different lives, leading a woman to re-evaluate what truly makes life worth living." },
            new Book { Title = "Klara and the Sun", Description = "An 'Artificial Friend' with outstanding observational qualities watches the world and learns about human nature from her position in a store." },
            new Book { Title = "A Gentleman in Moscow", Description = "An aristocrat, sentenced to house arrest in a grand hotel, discovers the true value of purpose, friendship, and love." },
            new Book { Title = "Educated: A Memoir", Description = "The story of a young woman who, kept out of school, leaves her survivalist family and goes on to earn a PhD from Cambridge University." }
        };

        IEnumerable<Book> filteredBooks = booksMockData;

        if (!string.IsNullOrEmpty(searchString))
        {
            filteredBooks = filteredBooks.Where(b => b.Title.ToLower().Contains(searchString.ToLower()));
        }

        var bookFilterViewModel = new BookFilterViewModel
        {
            Books = filteredBooks.ToList(),
            SearchString = searchString
        };
    
        return View(bookFilterViewModel);
    }
}