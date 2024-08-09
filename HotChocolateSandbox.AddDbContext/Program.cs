using HotChocolateSandbox.AddDbContext.Data;
using HotChocolateSandbox.AddDbContext.Seed;
using HotChocolateSandbox.AddDbContext.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HotChocolateSandboxDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

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