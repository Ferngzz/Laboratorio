using LaboratorioApplication.DTOs;
using LaboratorioApplication.DTOs.Book;

namespace LaboratorioApplication.IServices;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetAllBooksAsync();
    Task<IEnumerable<BookDTO>> GetAllBooksByAuthorIdAsync(Guid authorId);
    Task<BookDTO?> GetByBookIdAsync(Guid id);
    Task<IEnumerable<BookLoanDTO>> GetBooksLoanStatusByAuthorIdAsync(Guid authorId);
    Task<BookCreateDTO> AddBookAsync(BookDTO bookDto);
    Task UpdateBookByIdAsync(BookDTO bookDto, Guid id);
    Task DeleteBookByIdAsync(Guid id);
}