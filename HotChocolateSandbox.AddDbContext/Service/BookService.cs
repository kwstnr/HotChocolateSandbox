using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddDbContext.Data.HotChocolateSandboxDbContext;

namespace HotChocolateSandbox.AddDbContext.Service;

public class BookService(HotChocolateSandboxDbContext context)
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }
}