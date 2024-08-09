using HotChocolateSandbox.AddPooledDbContext.Seed;
using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<HotChocolateSandboxDbContext>(o
    => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddMigration<HotChocolateSandboxDbContext, HotChocolateSandboxSeed>();

builder.Services
    .AddScoped<BookService>()
    .AddScoped<AuthorService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);