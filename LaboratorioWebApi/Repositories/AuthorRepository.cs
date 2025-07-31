using LaboratorioDomain.Repositories;
using LaboratorioWebApi.Data;
using LaboratorioWebApi.Models;

namespace LaboratorioWebApi.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookshelfContext _context;

    public AuthorRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public Task<IEnumerable<Author>> GetAllAuthors()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> GetAllAuthorsByAuthorLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetByAuthorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAuthorById(Author author, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAuthorById(Guid id)
    {
        throw new NotImplementedException();
    }
}