using HotChocolateSandbox.api.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.api.Data;

public class HotChocolateSandboxDbContext(DbContextOptions<HotChocolateSandboxDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}