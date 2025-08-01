using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace LaboratorioInfrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookshelfContext _context;

    public AuthorRepository(BookshelfContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsByAuthorLastNameAsync(string lastName)
    {
        return await _context.Authors
            .Where(a => a.LastName.Contains(lastName))
            .ToListAsync();
    }

    public async Task<Author> GetByAuthorIdAsync(Guid id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task AddAuthorAsync (Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync(); 
    }

    public async Task UpdateAuthorByIdAsync(Author author, Guid id)
    { 
        var existingAuthor = await _context.Authors.FindAsync(id);

        if (existingAuthor != null)
        {
            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuthorByIdAsync(Guid id)
    {
        var existingAuthor = await _context.Authors.FindAsync(id);

        if (existingAuthor != null)
        {
            _context.Authors.Remove(existingAuthor);
        }
        
        await _context.SaveChangesAsync();
    }
}