using LaboratorioDomain.Repositories;
using LaboratorioWebApi.Data;
using LaboratorioWebApi.Models;

namespace LaboratorioWebApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookshelfContext _context;

    public BookRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Book>> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllBooksByAuthorId(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByBookId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookById(Book book, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookById(Guid id)
    {
        throw new NotImplementedException();
    }
}