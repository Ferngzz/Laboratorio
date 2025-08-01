using LaboratorioApplication.DTOs;

namespace LaboratorioApplication.IServices;

public interface IBookService
{
    Task<IEnumerable<BookDTO>> GetAllBooksAsync();
    Task<IEnumerable<BookDTO>> GetAllBooksByAuthorIdAsync(Guid authorId);
    Task<BookDTO> GetByBookIdAsync(Guid id);
    Task<BookCreateDTO> AddBookAsync(BookDTO bookDto);
    Task UpdateBookByIdAsync(BookDTO bookDto, Guid id);
    Task DeleteBookByIdAsync(Guid id);
}