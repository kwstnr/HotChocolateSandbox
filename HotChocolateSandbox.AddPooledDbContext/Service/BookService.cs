using HotChocolateSandbox.api.Data;
using HotChocolateSandbox.api.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Service;

public class BookService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }
}