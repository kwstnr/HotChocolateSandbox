using HotChocolate.v14Test.Services;
using HotChocolateSandbox.Data.Model;

namespace HotChocolate.v14Test.Types;

[MutationType]
public static class AuthorMutations
{
    public static async Task<Author> CreateAuthorAsync([Service] AuthorService authorService, string name) =>
        await authorService.CreateAuthorAsync(name); 
}