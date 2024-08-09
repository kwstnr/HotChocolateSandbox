using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;
using HotChocolateSandbox.Data.Model;

namespace HotChocolateSandbox.AddPooledDbContext.Types.Mutation;

[MutationType]
public static class BookMutations
{
    public static async Task<Book?> UpdateBookAsync([Service] ChangeBookTitleService changeBookTitleService, [Service] ChangeBookAuthorService changeBookAuthorService, [Service] BookService bookService, Guid bookId, string newTitle, string newAuthorName)
    {
        await changeBookTitleService.ChangeBookTitle(bookId, newTitle);
        await changeBookAuthorService.ChangeBookAuthor(bookId, Author.Create(newAuthorName));
        await changeBookTitleService.SaveChangesAsync();
        await changeBookAuthorService.SaveChangesAsync();
        return await bookService.GetBookByIdAsync(bookId);
    }
}