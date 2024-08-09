using Microsoft.EntityFrameworkCore;

namespace HotChocolateSandbox.api.Data;

public interface IDbSeeder<in TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}