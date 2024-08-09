using HotChocolateSandbox.AddPooledDbContext.Data;
using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;

public class ChangeBookAuthorService(HotChocolateSandboxDbContext context)
{
    public async Task<Book> ChangeBookAuthor(Book book, Author newAuthor)
    {
        await context.Authors.AddAsync(newAuthor);
        book.Author = newAuthor;
        context.Update(book);
        return book;
    }
}