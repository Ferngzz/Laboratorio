using LaboratorioDomain.Repositories;
using LaboratorioWebApi.Models;

namespace LaboratorioWebApi.Services;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<BookDTO>> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookDTO>> GetAllBooksByAuthorId(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public Task<BookDTO> GetByBookId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddBook(BookDTO bookDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookById(BookDTO bookDto, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookById(Guid id)
    {
        throw new NotImplementedException();
    }
}