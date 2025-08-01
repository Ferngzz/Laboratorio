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
        var existingAuthor = await _authorRepository.GetByAuthorIdAsync(id);

        if (existingAuthor == null)
        {
            throw new NullReferenceException($"No author with id: {id} was found.");
        }

        var author = _mapper.Map(authorDto, existingAuthor);
        await _authorRepository.UpdateAuthorByIdAsync(author, id);
    }

    public async Task DeleteAuthorByIdAsync(Guid id)
    {
        await _authorRepository.DeleteAuthorByIdAsync(id);
    }
}