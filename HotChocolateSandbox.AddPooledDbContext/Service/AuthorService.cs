using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddPooledDbContext.Data.HotChocolateSandboxDbContext;

namespace HotChocolateSandbox.AddPooledDbContext.Service;

public class AuthorService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }
}