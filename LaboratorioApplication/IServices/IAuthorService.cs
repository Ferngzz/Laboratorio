using LaboratorioApplication.DTOs;

namespace LaboratorioApplication.IServices;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDTO>> GetAllAuthorsAsync();
    Task<IEnumerable<AuthorDTO>> GetAllAuthorsByAuthorLastNameAsync(String lastName);
    Task<AuthorDTO?> GetByAuthorIdAsync(Guid id);
    Task<AuthorCreateDTO> AddAuthorAsync(AuthorDTO authorCreateDto);
    Task UpdateAuthorByIdAsync(AuthorDTO authorDto, Guid id);
    Task DeleteAuthorByIdAsync(Guid id);
}
