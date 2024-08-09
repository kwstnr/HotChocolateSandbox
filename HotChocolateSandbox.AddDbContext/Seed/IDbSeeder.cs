using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.AddDbContext.Seed;

public interface IDbSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}