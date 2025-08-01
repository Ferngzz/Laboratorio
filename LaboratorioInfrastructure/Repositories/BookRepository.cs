using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;

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
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> GetByBookIdAsync(Guid id)
    {
        throw new NotImplementedException();
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