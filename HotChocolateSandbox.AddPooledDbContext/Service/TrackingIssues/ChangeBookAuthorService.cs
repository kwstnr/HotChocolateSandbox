using HotChocolateSandbox.AddPooledDbContext.Data;
using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;

public class ChangeBookAuthorService(HotChocolateSandboxDbContext context)
{
    public async Task ChangeBookAuthor(Guid bookId, Author newAuthor)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        if (book != null)
        {
            await context.Authors.AddAsync(newAuthor);
            book.Author = newAuthor;
            
        }
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}