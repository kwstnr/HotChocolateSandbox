using HotChocolateSandbox.DbContextFactory.Data;
using HotChocolateSandbox.DbContextFactory.Seed;
using HotChocolateSandbox.DbContextFactory.Service;
using HotChocolateSandbox.DbContextFactory.Service.TrackingIssues;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<HotChocolateSandboxDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddMigration<HotChocolateSandboxDbContext, HotChocolateSandboxSeed>();

builder.Services
    .AddScoped<BookService>()
    .AddScoped<AuthorService>()
    .AddScoped<UpdateAuthorNameService>()
    .AddScoped<UpdateBookTitleService>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);