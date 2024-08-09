using HotChocolateSandbox.Data.Model;
using HotChocolateSandbox.DbContextFactory.Service;

namespace HotChocolateSandbox.DbContextFactory.Types.Query;

[QueryType]
public static class AuthorQueries
{
    public static async Task<IEnumerable<Author>> GetAuthorsAsync([Service] AuthorService authorService)
        => await authorService.GetAuthorsAsync();
}