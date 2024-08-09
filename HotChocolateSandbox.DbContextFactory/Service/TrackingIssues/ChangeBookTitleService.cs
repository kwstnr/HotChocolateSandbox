using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;

public class ChangeBookTitleService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    
    public Book ChangeBookTitle(Book book, string newTitle)
    {
        book.Title = newTitle;
        Context.Update(book);
        return book;
    }
}