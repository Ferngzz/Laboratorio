using LaboratorioWebApi.Models;
using LaboratorioWebApi.Repositories;

namespace LaboratorioWebApi.Services;

public class AuthorService
{
    private readonly AuthorRepository _repository;

    public AuthorService(AuthorRepository repository)
    {
        _repository = repository;
    }
    
    public Task<IEnumerable<AuthorDTO>> GetAllAuthors()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuthorDTO>> GetAllAuthorsByAuthorLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<AuthorDTO> GetByAuthorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAuthor(AuthorDTO authorDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAuthorById(AuthorDTO authorDto, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAuthorById(Guid id)
    {
        throw new NotImplementedException();
    }
}