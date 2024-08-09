using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.api.Model;

namespace HotChocolateSandbox.AddPooledDbContext.Types.Query;

[QueryType]
public static class AuthorQueries
{
    public static async Task<IEnumerable<Author>> GetAuthorsAsync([Service] AuthorService authorService)
        => await authorService.GetAuthorsAsync();
}