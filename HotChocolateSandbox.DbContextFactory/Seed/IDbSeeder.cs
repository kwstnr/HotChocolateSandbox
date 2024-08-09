using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.DbContextFactory.Seed;

public interface IDbSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}