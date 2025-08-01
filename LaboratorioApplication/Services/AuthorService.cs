using AutoMapper;
using LaboratorioApplication.DTOs;
using LaboratorioApplication.IServices;
using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;

namespace LaboratorioApplication.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public AuthorService(IAuthorRepository repository,  IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync()
    {
        var authors = await _repository.GetAllAuthorsAsync();
        return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
    }

    public async Task<IEnumerable<AuthorDTO>> GetAllAuthorsByAuthorLastNameAsync(string lastName)
    {
        var authors = await _repository.GetAllAuthorsByAuthorLastNameAsync(lastName);
        return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
    }

    public async Task<AuthorDTO?> GetByAuthorIdAsync(Guid id)
    {
        var author = await _repository.GetByAuthorIdAsync(id);
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task<AuthorCreateDTO> AddAuthorAsync(AuthorDTO authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        await _repository.AddAuthorAsync(author);
        
        return _mapper.Map<AuthorCreateDTO>(author);
    }

    public async Task UpdateAuthorByIdAsync(AuthorDTO authorDto, Guid id)
    {
        var author = _mapper.Map<Author>(authorDto);
        await _repository.UpdateAuthorByIdAsync(author, id);
    }

    public async Task DeleteAuthorByIdAsync(Guid id)
    {
        await _repository.DeleteAuthorByIdAsync(id);
    }
}