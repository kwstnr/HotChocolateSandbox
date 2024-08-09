using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddDbContext.Data.HotChocolateSandboxDbContext;

namespace HotChocolateSandbox.AddDbContext.Service;

public class AuthorService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }
}