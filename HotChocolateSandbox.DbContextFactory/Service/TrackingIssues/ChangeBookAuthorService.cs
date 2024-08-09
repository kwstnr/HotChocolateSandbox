using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;

public class ChangeBookAuthorService(IDbContextFactory<HotChocolateSandboxDbContext> contextFactory)
{
    private HotChocolateSandboxDbContext Context => _context ??= contextFactory.CreateDbContext(); 
    private HotChocolateSandboxDbContext? _context;
    
    public async Task<Book> ChangeBookAuthor(Book book, Author newAuthor)
    {
        await Context.Authors.AddAsync(newAuthor);
        book.Author = newAuthor;
        Context.Update(book);
        return book;
    }
}