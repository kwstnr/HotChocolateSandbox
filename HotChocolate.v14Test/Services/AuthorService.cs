using HotChocolate.v14Test.Data;
using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.v14Test.Services;

public class AuthorService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }
    
    public async Task<Author> CreateAuthorAsync(string name)
    {
        var author = Author.Create("name");
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }
}