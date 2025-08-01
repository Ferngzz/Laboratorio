using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LaboratorioInfrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookshelfContext _context;

    public BookRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Loans)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(Guid authorId)
    {
        return await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Loans)
            .Where(b => b.Authors.Any(a => a.AuthorId == authorId))
            .ToListAsync();
    }

    public async Task<Book> GetByBookIdAsync(Guid id)
    {
        return await _context.Books
            .Include(b => b.Authors)
            .Include(b => b.Loans)
            .FirstOrDefaultAsync(b => b.BookId == id);
    }
    
    public async Task<IEnumerable<Book>> GetBooksWithLoanStatusByAuthorIdAsync(Guid authorId)
    {
        return await _context.Books
            .Include(b => b.Loans)
            .Where(b => b.Authors.Any(a => a.AuthorId == authorId))
            .ToListAsync();
    }
    
    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookByIdAsync(Book book, Guid id)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookByIdAsync(Guid id)
    {
        var existingBook = await _context.Books.FindAsync(id);
        
        if (existingBook != null)
        {
            _context.Books.Remove(existingBook);
        }
        
        await _context.SaveChangesAsync();
    }
}