using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service;

public class AuthorService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await Context.Authors.ToListAsync();
    }
}