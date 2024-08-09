using HotChocolateSandbox.AddPooledDbContext.Data;
using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;

public class ChangeBookTitleService(HotChocolateSandboxDbContext context)
{

    public Book ChangeBookTitle(Book book, string newTitle)
    {
        book.Title = newTitle;
        context.Update(book);
        return book;
    }
}