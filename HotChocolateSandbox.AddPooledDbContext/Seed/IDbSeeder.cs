using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddPooledDbContext.Seed;

public interface IDbSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}