using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Service;

namespace HotChocolateSandbox.DbContextFactory.Types.Query;

[QueryType]
public static class BookQueries
{
    public static async Task<IEnumerable<Book>> GetBooksAsync([Service] BookService bookService)
        => await bookService.GetBooksAsync();
    
    public static async Task<Book?> GetBookByIdAsync([Service] BookService bookService, Guid id)
        => await bookService.GetBookByIdWithAuthorAsync(id);
}