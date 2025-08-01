using AutoMapper;
using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;

namespace LaboratorioApplication.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository,  IMapper mapper)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
    {
        var authors = await _authorRepository.GetAllAuthorsAsync();
        return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
    }

    public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsByAuthorLastNameAsync(string lastName)
    {
        var authors = await _authorRepository.GetAllAuthorsByAuthorLastNameAsync(lastName);
        return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
    }

    public async Task<AuthorDTO?> GetByAuthorIdAsync(Guid id)
    {
        var author = await _authorRepository.GetByAuthorIdAsync(id);
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task<AuthorCreateDTO> AddAuthorAsync(AuthorDTO authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        await _authorRepository.AddAuthorAsync(author);
        
        return _mapper.Map<AuthorCreateDTO>(author);
    }

    public async Task UpdateAuthorByIdAsync(AuthorDTO authorDto, Guid id)
    {
        var author = await _authorRepository.GetByAuthorIdAsync(id); 

        if (author == null)
            throw new Exception("Author not found");

        author.FirstName = authorDto.FirstName;
        author.LastName = authorDto.LastName;

        if (authorDto.Books.Any())
        {
            var books = new List<Book>();
            foreach (var bookId in authorDto.Books)
            {
                var book = await _bookRepository.GetByBookIdAsync(bookId);
                if (book == null)
                    throw new Exception($"Book not found with ID: {bookId}");

                books.Add(book);
            }

            author.Books = books; 
        }
        else
        {
            author.Books.Clear();
        }

        await _authorRepository.UpdateAuthorByIdAsync(author, id);
    }

    public async Task DeleteAuthorByIdAsync(Guid id)
    {
        await _authorRepository.DeleteAuthorByIdAsync(id);
    }
}