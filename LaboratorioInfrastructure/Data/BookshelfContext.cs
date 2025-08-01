using LaboratorioDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioInfrastructure.Data;

public class BookshelfContext : DbContext
{
    public BookshelfContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Loan> Loans { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);
    }
    
    
}