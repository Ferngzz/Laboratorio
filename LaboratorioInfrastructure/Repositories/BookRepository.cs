using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        return await _context.Books.ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(Guid authorId)
    {
        return await _context.Books
            .Where(b => b.Authors.Any(a => a.AuthorId == authorId))
            .ToListAsync();
    }

    public async Task<Book> GetByBookIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateBookByIdAsync(Book book, Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBookByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}