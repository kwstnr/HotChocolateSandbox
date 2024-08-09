using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service;

public class BookService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await Context.Books.ToListAsync();
    }

    
    public async Task<Book?> GetBookByIdAsync(Guid id)
        => await Context.Books.FirstOrDefaultAsync(b => b.Id == id);
}