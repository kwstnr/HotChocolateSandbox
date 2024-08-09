using HotChocolateSandbox.AddDbContext.Service;
using HotChocolateSandbox.Data.Model;

namespace HotChocolateSandbox.AddDbContext.Types.Query;

[QueryType]
public static class BookQueries
{
    public static async Task<IEnumerable<Book>> GetBooksAsync([Service] BookService bookService)
        => await bookService.GetBooksAsync();
}