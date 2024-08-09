using HotChocolateSandbox.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddDbContext.Data.HotChocolateSandboxDbContext;

namespace HotChocolateSandbox.AddDbContext.Seed;

public class HotChocolateSandboxSeed: IDbSeeder<HotChocolateSandboxDbContext>
{
    public async Task SeedAsync(HotChocolateSandboxDbContext context)
    {
        await context.Database.OpenConnectionAsync();
        await ((NpgsqlConnection)context.Database.GetDbConnection()).ReloadTypesAsync();

        if (!context.Books.Any())
        {
            var books = new List<Book>();
            for (int authorNumber = 1; authorNumber <= 5; authorNumber++)
            {
                Author author = Author.Create($"Author {authorNumber}");
                for (int bookNumber = 1; bookNumber <= 5; bookNumber++)
                {
                    books.Add(Book.Create($"Book {authorNumber}{bookNumber}", author));
                }
            }
            
            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();
        }
    }
}