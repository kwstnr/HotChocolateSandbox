using HotChocolateSandbox.AddPooledDbContext.Seed;
using HotChocolateSandbox.AddPooledDbContext.Service;
using HotChocolateSandbox.AddPooledDbContext.Service.TrackingIssues;
using Microsoft.EntityFrameworkCore;
using HotChocolateSandboxDbContext = HotChocolateSandbox.AddPooledDbContext.Data.HotChocolateSandboxDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<HotChocolateSandboxDbContext>(o
    => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddMigration<HotChocolateSandboxDbContext, HotChocolateSandboxSeed>();

builder.Services
    .AddScoped<BookService>()
    .AddScoped<AuthorService>()
    .AddScoped<ChangeBookAuthorService>()
    .AddScoped<ChangeBookTitleService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);