using HotChocolateSandbox.AddPooledDbContext.Data;
using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;

public class ChangeBookTitleService(HotChocolateSandboxDbContext context)
{

    public async Task ChangeBookTitle(Guid bookId, string newTitle)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        if (book != null)
        {
            book.Title = newTitle;
        }
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}