using HotChocolateSandbox.api.Model;
using HotChocolateSandbox.api.Service;

namespace HotChocolateSandbox.api.Types.Query;

[QueryType]
public static class BookQueries
{
    public static async Task<IEnumerable<Book>> GetBooksAsync([Service] BookService bookService)
        => await bookService.GetBooksAsync();
}