using AutoMapper;
using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;

namespace LaboratorioApplication.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private  readonly IMapper _mapper;

    public BookService(IBookRepository repository,  IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
    {
        var books = await _repository.GetAllBooksAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooksByAuthorIdAsync(Guid authorId)
    {
        var books = await _repository.GetAllBooksByAuthorIdAsync(authorId);
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<BookDTO> GetByBookIdAsync(Guid id)
    {   
        var book = await _repository.GetByBookIdAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task AddBookAsync(BookDTO bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _repository.AddBookAsync(book);
    }

    public async Task UpdateBookByIdAsync(BookDTO bookDto, Guid id)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _repository.UpdateBookByIdAsync(book, id);
    }

    public async Task DeleteBookByIdAsync(Guid id)
    {
        await  _repository.DeleteBookByIdAsync(id);
    }
}