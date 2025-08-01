using LaboratorioDomain.Models;

namespace LaboratorioDomain.IRepositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<IEnumerable<Book>> GetAllBooksByAuthorIdAsync(Guid authorId);
    Task<Book> GetByBookIdAsync(Guid id);
    Task<IEnumerable<Book>> GetBooksWithLoanStatusByAuthorIdAsync(Guid authorId);
    Task AddBookAsync(Book book);
    Task UpdateBookByIdAsync(Book book, Guid id);
    Task DeleteBookByIdAsync(Guid id);
}