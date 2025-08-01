using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioInfrastructure.MockData;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookshelfContext(
                   serviceProvider.GetRequiredService<DbContextOptions<BookshelfContext>>()))
        {
            Console.WriteLine("--> Attempting to seed data...");

            if (context.Authors.Any())
            {
                Console.WriteLine("--> Found existing data. Seeding not required.");
                return;
            }

            Console.WriteLine("--> Seeding new data...");

            var author1 = new Author { AuthorId = Guid.NewGuid(), FirstName = "J.R.R.", LastName = "Tolkien" };
            var author2 = new Author { AuthorId = Guid.NewGuid(), FirstName = "C.S.", LastName = "Lewis" };

            context.Authors.AddRange(author1, author2);

            var book1 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "The Hobbit",
                Description = "A fantasy novel.",
                Authors = new List<Author> { author1 }
            };

            var book2 = new Book
            {
                BookId = Guid.NewGuid(),
                Title = "The Lion, the Witch and the Wardrobe",
                Description = "A fantasy novel for children.",
                Authors = new List<Author> { author2 }
            };

            context.Books.AddRange(book1, book2);

            // Mock loans
            var loan1 = new Loan
            {
                LoanId = Guid.NewGuid(),
                BookId = book1.BookId,
                WithdrawalDate = DateTime.UtcNow.AddDays(-10),
                DevolutionDate = DateTime.UtcNow.AddDays(10),
                Returned = false
            };

            var loan2 = new Loan
            {
                LoanId = Guid.NewGuid(),
                BookId = book2.BookId,
                WithdrawalDate = DateTime.UtcNow.AddDays(-20),
                DevolutionDate = DateTime.UtcNow.AddDays(-5),
                Returned = true
            };
            
            book1.Loans = new List<Loan> { loan1 };
            book2.Loans = new List<Loan> { loan2 };
            
            context.Loans.AddRange(loan1, loan2);

            var recordsSaved = context.SaveChanges();
            Console.WriteLine($"--> Seeding finished. {recordsSaved} records saved.");
        }
    }

}