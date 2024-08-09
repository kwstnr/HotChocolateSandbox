using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Data;

public class HotChocolateSandboxDbContext(DbContextOptions<HotChocolateSandboxDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}