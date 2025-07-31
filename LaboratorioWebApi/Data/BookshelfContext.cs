using LaboratorioWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data;

public class BookshelfContext : DbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    // DbSet<AuthorBook> AuthorBooks { get; set; }
    DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string path = "C:\\Users\\Fernando_S\\RiderProjects\\Laboratorio\\LaboratorioWebApi\\Data\\Bookshelf.db";
        optionsBuilder.UseSqlite($"data source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected BookshelfContext()
    {
    }

    public BookshelfContext(DbContextOptions options) : base(options)
    {
    }
}