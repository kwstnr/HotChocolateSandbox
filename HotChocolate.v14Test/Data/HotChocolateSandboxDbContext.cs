using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.v14Test.Data;

public class HotChocolateSandboxDbContext(DbContextOptions<HotChocolateSandboxDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}