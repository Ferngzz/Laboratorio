using LaboratorioWebApi.Models;

namespace LaboratorioDomain.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooks();
    Task<IEnumerable<Book>> GetAllBooksByAuthorId(Guid authorId);
    Task<Book> GetByBookId(Guid id);
    Task AddBook(Book book);
    Task UpdateBookById(Book book, Guid id);
    Task DeleteBookById(Guid id);
}