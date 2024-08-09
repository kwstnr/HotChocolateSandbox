using HotChocolateSandbox.AddDbContext.Data;
using HotChocolateSandbox.AddDbContext.Service;
using HotChocolateSandbox.Data.Model;

namespace HotChocolateSandbox.AddDbContext.Types.Query;

[QueryType]
public static class BookQueries
{
    public static async Task<IEnumerable<Book>> GetBooksAsync([Service] BookService bookService)
        => await bookService.GetBooksAsync();

    // public static async Task<IEnumerable<Book>> GetBooks2Async(
    //     [Service(ServiceKind.Synchronized)] BookService bookService)
    //     => await bookService.GetBooksAsync();
    
    [UseFirstOrDefault]
    public static IQueryable<Book?> GetBookById(HotChocolateSandboxDbContext context, Guid id)
        => context.Books.Where(b => b.Id == id);
}