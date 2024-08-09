using HotChocolateSandbox.AddPooledDbContext.Data;
using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;
using HotChocolateSandbox.Data.Model;

namespace HotChocolateSandbox.AddPooledDbContext.Types.Mutation;

[MutationType]
public static class BookMutations
{
    public static async Task<Book?> UpdateBookAsync([Service] ChangeBookTitleService changeBookTitleService, [Service] ChangeBookAuthorService changeBookAuthorService, [Service] BookService bookService, [Service] HotChocolateSandboxDbContext context,  Guid bookId, string newTitle, string newAuthorName)
    {
        var book = await bookService.GetBookByIdAsync(bookId);
        if (book != null)
        {
            var updatedBook = changeBookTitleService.ChangeBookTitle(book, newTitle);
            var newestBook = await changeBookAuthorService.ChangeBookAuthor(updatedBook, Author.Create(newAuthorName));
            await context.SaveChangesAsync();
            return newestBook;
        }

        return null;
    }
}
