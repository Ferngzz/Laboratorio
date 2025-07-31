using LaboratorioWebApi.Models;

namespace LaboratorioDomain.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<IEnumerable<Author>> GetAllAuthorsByAuthorLastName(String lastName);
    Task<Author> GetByAuthorId(Guid id);
    Task AddAuthor(Author author);
    Task UpdateAuthorById(Author author, Guid id);
    Task DeleteAuthorById(Guid id);
}
