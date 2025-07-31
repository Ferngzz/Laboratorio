using LaboratorioWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWebApi.Data;

public class BookshelfContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    public BookshelfContext(DbContextOptions options) : base(options)
    {
    }

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
    
}