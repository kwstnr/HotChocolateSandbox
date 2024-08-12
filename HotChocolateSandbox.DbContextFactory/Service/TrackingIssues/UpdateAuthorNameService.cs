using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;

public class UpdateAuthorNameService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    
    public async Task<Author> ChangeAuthorName(Guid authorId, string newAuthorName)
    {
        var author = await Context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
        if (author == null)
            throw new ArgumentException($"Author with Id {authorId} not found");
        
        author.Name = newAuthorName;
        Context.Authors.Update(author);
        return author;
    }
    
    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}