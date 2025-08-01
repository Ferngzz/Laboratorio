using LaboratorioDomain.IRepositories;
using LaboratorioDomain.Models;
using LaboratorioInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


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
        return await _context.Authors
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsByAuthorLastNameAsync (string lastName)
    {
        lastName = lastName?.Trim().ToLower();

        return await _context.Authors
            .Include(a => a.Books)
            .Where(a => a.LastName != null && 
                        EF.Functions.Like(a.LastName.ToLower(), $"%{lastName}%"))
            .ToListAsync();
    }

    public async Task<Author> GetByAuthorIdAsync(Guid id)
    {
        return await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.AuthorId == id);
    }

    public async Task AddAuthorAsync (Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync(); 
    }

    public async Task UpdateAuthorByIdAsync(Author author, Guid id)
    {
        _context.Authors.Update(author);
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