using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Data;
using HotChocolateSandbox.DbContextFactory.Service;
using HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;

namespace HotChocolateSandbox.DbContextFactory.Types.Mutation;

[MutationType]
public static class BookMutations
{
    public static async Task<Book?> UpdateBookAsync([Service] UpdateBookTitleService updateBookTitleService, [Service] UpdateAuthorNameService updateAuthorNameService, [Service] BookService bookService, [Service] HotChocolateSandboxDbContext context,  Guid bookId, string newTitle, string newAuthorName)
    {
        var book = await bookService.GetBookByIdWithAuthorAsync(bookId);
        if (book == null)
            throw new ArgumentException($"Book with Id {bookId} not found");
            
        await updateBookTitleService.ChangeBookTitle(bookId, newTitle);
        await updateAuthorNameService.ChangeAuthorName(book.Author.Id, newAuthorName);
        await updateBookTitleService.SaveChangesAsync();
        await updateAuthorNameService.SaveChangesAsync();
        return book = await bookService.GetBookByIdWithAuthorAsync(bookId);
    }
}
