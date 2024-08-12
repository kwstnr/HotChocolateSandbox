using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;

public class UpdateBookTitleService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    
    public async Task<Book> ChangeBookTitle(Guid bookId, string newTitle)
    {
        var book = await Context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);
        if (book == null)
            throw new ArgumentException($"book with Id {bookId} not found");
        
        book.Title = newTitle;
        Context.Books.Update(book);
        return book;
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}