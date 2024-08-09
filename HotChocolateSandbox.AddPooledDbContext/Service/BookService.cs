using HotChocolateSandbox.api.Model;
using Microsoft.EntityFrameworkCore;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddPooledDbContext.Data.HotChocolateSandboxDbContext;

namespace HotChocolateSandbox.AddPooledDbContext.Service;

public class BookService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }
}