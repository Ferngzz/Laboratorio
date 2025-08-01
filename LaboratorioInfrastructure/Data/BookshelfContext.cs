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

        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBook",
                ab => ab.HasOne<Book>().WithMany().HasForeignKey("BooksBookId"),
                ab => ab.HasOne<Author>().WithMany().HasForeignKey("AuthorsAuthorId"));
    }
    
    
}