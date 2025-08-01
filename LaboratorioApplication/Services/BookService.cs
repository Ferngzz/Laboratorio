using AutoMapper;
using LaboratorioApplication.DTOs.Book;
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

    public async Task<BookDTO?> GetByBookIdAsync(Guid id)
    {   
        var book = await _repository.GetByBookIdAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task<IEnumerable<BookLoanDTO>> GetBooksLoanStatusByAuthorIdAsync(Guid authorId)
    {
        var books = await _repository.GetBooksWithLoanStatusByAuthorIdAsync(authorId);

        var result = books.Select(book =>
        {
            var activeLoan = book.Loans.FirstOrDefault(l => !l.Returned);

            return new BookLoanDTO
            {
                Title = book.Title,
                Description = book.Description,
                Returned = activeLoan == null,
                DevolutionDate = activeLoan?.DevolutionDate ?? DateTime.MinValue
            };
        });

        return result;
    }
    
    public async Task<BookCreateDTO> AddBookAsync(BookDTO bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _repository.AddBookAsync(book);
        return _mapper.Map<BookCreateDTO>(book);
    }

    public async Task UpdateBookByIdAsync(BookDTO bookDto, Guid id)
    {
        var existingBook = await _repository.GetByBookIdAsync(id);

        if (existingBook == null)
        {
            throw new NullReferenceException($"No author with id: {id} was found.");
        }
        
        var book = _mapper.Map(bookDto, existingBook);
        await _repository.UpdateBookByIdAsync(book, id);
    }

    public async Task DeleteBookByIdAsync(Guid id)
    {
        await  _repository.DeleteBookByIdAsync(id);
    }
    
    
}