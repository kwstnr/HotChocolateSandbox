using HotChocolateSandbox.AddDbContext.Service;
using HotChocolateSandbox.Data.Model;

namespace HotChocolateSandbox.AddDbContext.Types.Query;

[QueryType]
public static class AuthorQueries
{
    public static async Task<IEnumerable<Author>> GetAuthorsAsync([Service(ServiceKind.Synchronized)] AuthorService authorService)
        => await authorService.GetAuthorsAsync();
}