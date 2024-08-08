using HotChocolateSandbox.api.Model;
using HotChocolateSandbox.api.Service;

namespace HotChocolateSandbox.api.Types.Query;

[QueryType]
public static class AuthorQueries
{
    public static async Task<IEnumerable<Author>> GetAuthorsAsync([Service] AuthorService authorService)
        => await authorService.GetAuthorsAsync();
}