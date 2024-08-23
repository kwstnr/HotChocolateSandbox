using HotChocolate.v14Test.Services;
using HotChocolateSandbox.Data.Model;

namespace HotChocolate.v14Test.Types;

[QueryType]
public static class AuthorQueries
{
    public static async Task<IEnumerable<Author>> GetAuthorsAsync([Service] AuthorService authorService) =>
        await authorService.GetAuthorsAsync();
}