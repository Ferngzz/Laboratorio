using LaboratorioDomain.Models;

namespace LaboratorioDomain.IRepositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<IEnumerable<Author>> GetAllAuthorsByAuthorLastNameAsync(String lastName);
    Task<Author> GetByAuthorIdAsync(Guid id);
    Task AddAuthorAsync(Author author);
    Task UpdateAuthorByIdAsync(Author author, Guid id);
    Task DeleteAuthorByIdAsync(Guid id);
}
