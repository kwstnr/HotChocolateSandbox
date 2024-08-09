using HotChocolateSandbox.api.Data;
using HotChocolateSandbox.api.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.api.Service;

public class AuthorService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }
}