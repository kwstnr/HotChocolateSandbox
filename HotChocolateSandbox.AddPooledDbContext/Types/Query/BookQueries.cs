using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.api.Model;

namespace HotChocolateSandbox.AddPooledDbContext.Types.Query;

[QueryType]
public static class BookQueries
{
    public static async Task<IEnumerable<Book>> GetBooksAsync([Service] BookService bookService)
        => await bookService.GetBooksAsync();
}